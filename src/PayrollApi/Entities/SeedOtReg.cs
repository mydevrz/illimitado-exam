namespace PayrollApi.Entities;

public static partial class SeedData
{
    public static OtReg[] OtRegs => new[]
    {
        new OtReg { Id = 1, PayrollNo = 61, PayDate = new DateTime(2020, 3, 31), PayCode = "BROADSPIRE-SEMI", EmployeeId = 67008, LastName = "GARCIA", FirstName = "ANNELIE", FileStatus = "EMPLOYEE", OtCode = "NITE-DIFF", Date = new DateTime(2020, 3, 24), CostCenter = 5035, OtRate = 0.15m, OtHours = 80.0m, OtAmount = 3426.7m, OtNpHours = 0.0m, OtNpAmount = 0.0m, OtNp2Hours = 0.0m, OtNp2Amount = 0.0m, OtAndNpAmount = 3426.7m, Remarks = "UPLOADED FROM EXCEL", SystemOtHours = 80.0m, SystemOtTime = "00080:00000", SystemNpHours = 0.0m, SystemNpTime = "00000:00000", From = new DateTime(2020, 3, 16), To = new DateTime(2020, 3, 31), JeCostCenter = 5035 },
        new OtReg { Id = 2, PayrollNo = 61, PayDate = new DateTime(2020, 3, 31), PayCode = "BROADSPIRE-SEMI", EmployeeId = 67008, LastName = "GARCIA", FirstName = "ANNELIE", FileStatus = "EMPLOYEE", OtCode = "REG-OT", Date = new DateTime(2020, 3, 24), CostCenter = 5035, OtRate = 1.25m, OtHours = 4.0m, OtAmount = 1427.79m, OtNpHours = 0.0m, OtNpAmount = 0.0m, OtNp2Hours = 0.0m, OtNp2Amount = 0.0m, OtAndNpAmount = 1427.79m, Remarks = "UPLOADED FROM EXCEL", SystemOtHours = 4.0m, SystemOtTime = "00004:00000", SystemNpHours = 0.0m, SystemNpTime = "00000:00000", From = new DateTime(2020, 3, 16), To = new DateTime(2020, 3, 31), JeCostCenter = 5035 },
        new OtReg { Id = 3, PayrollNo = 61, PayDate = new DateTime(2020, 3, 31), PayCode = "BROADSPIRE-SEMI", EmployeeId = 67008, LastName = "GARCIA", FirstName = "ANNELIE", FileStatus = "EMPLOYEE", OtCode = "REG-OT", Date = new DateTime(2020, 3, 25), CostCenter = 5035, OtRate = 1.25m, OtHours = 0.0m, OtAmount = 0.0m, OtNpHours = 4.0m, OtNpAmount = 214.17m, OtNp2Hours = 0.0m, OtNp2Amount = 0.0m, OtAndNpAmount = 214.17m, Remarks = "UPLOADED FROM EXCEL", SystemOtHours = 0.0m, SystemOtTime = "00000:00000", SystemNpHours = 4.0m, SystemNpTime = "00004:00000", From = new DateTime(2020, 3, 16), To = new DateTime(2020, 3, 31), JeCostCenter = 5035 },
    };
}
