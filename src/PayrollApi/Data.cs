using Microsoft.EntityFrameworkCore;
using PayrollApi.Entities;

namespace PayrollApi;

public class PayrollDbContext : DbContext
{
    public PayrollDbContext(DbContextOptions<PayrollDbContext> options) : base(options) { }

    public DbSet<PayReg> PayRegs => Set<PayReg>();
    public DbSet<OtReg> OtRegs => Set<OtReg>();
    public DbSet<TimeAttendance> TimeAttendances => Set<TimeAttendance>();
    public DbSet<EmpMaster> EmpMasters => Set<EmpMaster>();
    public DbSet<OtRate> OtRates => Set<OtRate>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<PayReg>().HasIndex(x => x.PayrollNo);
        b.Entity<OtReg>().HasIndex(x => x.PayrollNo);
        b.Entity<TimeAttendance>().HasIndex(x => x.PayrollNo);
        b.Entity<EmpMaster>().HasIndex(x => x.EmployeeId).IsUnique();
        b.Entity<OtRate>().HasIndex(x => x.Key).IsUnique();

        b.Entity<PayReg>().HasData(SeedData.PayRegs);
        b.Entity<OtReg>().HasData(SeedData.OtRegs);
        b.Entity<EmpMaster>().HasData(SeedData.EmpMasters);
        b.Entity<OtRate>().HasData(SeedData.OtRates);
    }
}
