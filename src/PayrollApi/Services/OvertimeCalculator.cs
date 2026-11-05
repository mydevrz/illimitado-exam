using Microsoft.EntityFrameworkCore;
using PayrollApi.Entities;

namespace PayrollApi.Services;

public record OvertimeRow(int EmployeeId, string LastName, string FirstName, decimal AttDeduction, decimal Overtime);

/// <summary>
/// Converts the workbook's Calculator sheet (and PAYREG columns M and N) to C#/LINQ.
///
/// Hourly rate = Monthly salary x 12 / 261 / 8, daily rate = Monthly salary x 12 / 261 (no 8 divisor).
/// Line amount = rate x premium rate (Calculator row 8) x hours or days, rounded to 2 places.
/// ATT DEDUCTION (PAYREG!M) = -(tardy + undertime + absent + LWOP amounts). Paid leave is not deducted.
/// OVERTIME      (PAYREG!N) = sum of every night-differential and OT amount (Calculator columns V to CD).
/// REG DAYS WRK is only income when the pay type is Daily, so it is outside both totals.
/// </summary>
public class OvertimeCalculator
{
    private const decimal WorkDaysPerYear = 261m;
    private const decimal HoursPerDay = 8m;

    private static readonly Dictionary<string, Func<TimeAttendance, decimal>> Quantity =
        typeof(TimeAttendance).GetProperties()
            .Where(p => p.PropertyType == typeof(decimal?))
            .ToDictionary(p => p.Name, p => (Func<TimeAttendance, decimal>)(t => (decimal?)p.GetValue(t) ?? 0m));

    private readonly PayrollDbContext _db;

    public OvertimeCalculator(PayrollDbContext db) => _db = db;

    public async Task<List<OvertimeRow>> ComputeAsync(int payrollNo, CancellationToken ct = default)
    {
        var rates = await _db.OtRates.AsNoTracking().Where(r => r.Category != "Excluded").ToListAsync(ct);
        var attendance = await _db.TimeAttendances.AsNoTracking().Where(t => t.PayrollNo == payrollNo).ToListAsync(ct);
        var employees = await _db.EmpMasters.AsNoTracking().ToDictionaryAsync(e => e.EmployeeId, ct);

        return (from t in attendance
                where t.EmployeeId != null && employees.ContainsKey(t.EmployeeId.Value)
                let emp = employees[t.EmployeeId!.Value]
                let daily = emp.MonthlySalary * 12m / WorkDaysPerYear
                let hourly = daily / HoursPerDay
                let lines = (from r in rates
                             let qty = Quantity.TryGetValue(r.Key, out var get) ? get(t) : 0m
                             select new
                             {
                                 r.Category,
                                 Amount = Math.Round((r.Unit == "Days" ? daily : hourly) * r.PremiumRate * qty, 2, MidpointRounding.AwayFromZero)
                             }).ToList()
                orderby emp.LastName, emp.FirstName
                select new OvertimeRow(
                    emp.EmployeeId, emp.LastName, emp.FirstName,
                    -lines.Where(l => l.Category == "Deduction").Sum(l => l.Amount),
                    lines.Where(l => l.Category == "Overtime").Sum(l => l.Amount))
               ).ToList();
    }
}
