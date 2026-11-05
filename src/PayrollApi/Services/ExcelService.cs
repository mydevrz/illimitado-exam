using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Reflection;
using ClosedXML.Excel;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using PayrollApi.Entities;

namespace PayrollApi.Services;

public class ExcelService
{
    private readonly PayrollDbContext _db;

    public ExcelService(PayrollDbContext db) => _db = db;

    /// <summary>Test 3: reads the uploaded workbook and bulk inserts it into TimeAttendance.</summary>
    public async Task<int> UploadTimeAttendanceAsync(Stream xlsx, int payrollNo, CancellationToken ct = default)
    {
        using var wb = new XLWorkbook(xlsx);
        var ws = wb.Worksheets.FirstOrDefault(w => w.Name.Equals("TimeAttendance", StringComparison.OrdinalIgnoreCase)
                                                 || w.Name.Equals("Attendance", StringComparison.OrdinalIgnoreCase))
                 ?? wb.Worksheets.First();

        var props = typeof(TimeAttendance).GetProperties()
            .Select(p => (Prop: p, Col: p.GetCustomAttribute<ColumnAttribute>()?.Name))
            .Where(x => x.Col != null)
            .ToDictionary(x => Normalize(x.Col!), x => x.Prop);

        var map = new Dictionary<int, PropertyInfo>();
        foreach (var cell in ws.Row(1).CellsUsed())
            if (props.TryGetValue(Normalize(cell.GetString()), out var p))
                map[cell.Address.ColumnNumber] = p;

        var rows = new List<TimeAttendance>();
        foreach (var row in ws.RowsUsed().Skip(1))
        {
            var t = new TimeAttendance { PayrollNo = payrollNo };
            foreach (var (col, prop) in map)
            {
                if (prop.Name == nameof(TimeAttendance.PayrollNo)) continue; // the parameter wins
                SetValue(t, prop, row.Cell(col));
            }
            if (t.EmployeeId != null) rows.Add(t);
        }

        await using var tx = await _db.Database.BeginTransactionAsync(ct);
        await _db.TimeAttendances.Where(x => x.PayrollNo == payrollNo).ExecuteDeleteAsync(ct);
        await _db.BulkInsertAsync(rows, cancellationToken: ct);
        await tx.CommitAsync(ct);
        return rows.Count;
    }

    /// <summary>Test 4: one workbook, sheet 1 = PAYREG, sheet 2 = OTR, both filtered by Payroll #.</summary>
    public async Task<byte[]> ExportPayrollAsync(int payrollNo, CancellationToken ct = default)
    {
        using var wb = new XLWorkbook();
        Write(wb.Worksheets.Add("PAYREG"), await _db.PayRegs.AsNoTracking().Where(x => x.PayrollNo == payrollNo).OrderBy(x => x.Id).ToListAsync(ct));
        Write(wb.Worksheets.Add("OTR"), await _db.OtRegs.AsNoTracking().Where(x => x.PayrollNo == payrollNo).OrderBy(x => x.Id).ToListAsync(ct));
        return Save(wb);
    }

    /// <summary>Intermediate test: the five calculated columns.</summary>
    public static byte[] ExportOvertime(IReadOnlyList<OvertimeRow> rows)
    {
        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("OTREG");
        string[] headers = { "EMPLOYEE ID #", "LAST NAME", "FIRST NAME", "ATT DEDUCTION", "OVERTIME" };
        for (var i = 0; i < headers.Length; i++) ws.Cell(1, i + 1).Value = headers[i];
        ws.Row(1).Style.Font.Bold = true;
        for (var r = 0; r < rows.Count; r++)
        {
            ws.Cell(r + 2, 1).Value = rows[r].EmployeeId;
            ws.Cell(r + 2, 2).Value = rows[r].LastName;
            ws.Cell(r + 2, 3).Value = rows[r].FirstName;
            ws.Cell(r + 2, 4).Value = rows[r].AttDeduction;
            ws.Cell(r + 2, 5).Value = rows[r].Overtime;
        }
        if (rows.Count > 0) ws.Range(2, 4, rows.Count + 1, 5).Style.NumberFormat.Format = "#,##0.00;-#,##0.00";
        ws.Columns().AdjustToContents();
        return Save(wb);
    }

    private static void Write<T>(IXLWorksheet ws, List<T> items)
    {
        var cols = typeof(T).GetProperties()
            .Select(p => (Prop: p, Name: p.GetCustomAttribute<ColumnAttribute>()?.Name))
            .Where(x => x.Name != null).ToList();

        for (var c = 0; c < cols.Count; c++) ws.Cell(1, c + 1).Value = cols[c].Name;
        ws.Row(1).Style.Font.Bold = true;

        for (var r = 0; r < items.Count; r++)
            for (var c = 0; c < cols.Count; c++)
            {
                var v = cols[c].Prop.GetValue(items[r]);
                var cell = ws.Cell(r + 2, c + 1);
                switch (v)
                {
                    case null: break;
                    case DateTime d: cell.Value = d; cell.Style.DateFormat.Format = "yyyy-mm-dd"; break;
                    case decimal m: cell.Value = m; break;
                    case int i: cell.Value = i; break;
                    default: cell.Value = v.ToString(); break;
                }
            }
        ws.SheetView.FreezeRows(1);
        ws.Columns().AdjustToContents();
    }

    private static void SetValue(TimeAttendance t, PropertyInfo prop, IXLCell cell)
    {
        if (cell.IsEmpty()) return;
        var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
        var text = cell.GetString().Trim();
        if (text.Length == 0 || text == "-") return; // blank or the "  -  " placeholder used by the sheets

        if (type == typeof(string)) prop.SetValue(t, text);
        else if (type == typeof(int)) prop.SetValue(t, (int)Math.Round(cell.GetDouble()));
        else if (type == typeof(decimal))
            prop.SetValue(t, cell.DataType == XLDataType.Number ? (decimal)cell.GetDouble() : decimal.Parse(text, CultureInfo.InvariantCulture));
    }

    private static string Normalize(string s) => new string(s.Where(char.IsLetterOrDigit).ToArray()).ToUpperInvariant();

    private static byte[] Save(XLWorkbook wb)
    {
        using var ms = new MemoryStream();
        wb.SaveAs(ms);
        return ms.ToArray();
    }
}
