# Illimitado Dev Exam

.NET 7 minimal API (no controllers), EF Core 7 code-first, PostgreSQL, ClosedXML, EFCore.BulkExtensions 7.1.6 (MIT).

## Run

1. PostgreSQL 16 running on `localhost:5432`.
2. Put the connection string in `src/PayrollApi/appsettings.Development.json` (git-ignored; `appsettings.json` has a placeholder).
3. `dotnet ef database update --project src/PayrollApi` (creates the tables and the seed data). The API also applies the migration on start-up.
4. `dotnet run --project src/PayrollApi --urls http://localhost:5080`, then open `/swagger`.

`global.json` pins the .NET 7 SDK (7.0.410).

## Easy level

| Test | Where |
|---|---|
| 1 Tables | `Entities/PayReg.cs`, `OtReg.cs`, `TimeAttendance.cs`. Column names are Row 1 of each sheet, verbatim. `TimeAttendance` has the extra `PAYROLL #`. Migration: `Migrations/*_InitialCreate.cs`. |
| 2 Seed | `Entities/Seed*.cs`, loaded with `HasData`. 3 rows each for PAYREG and OTREG. |
| 3 Upload | `POST /api/timeattendance/upload?payrollNo=61` with an `.xlsx` (form field `file`). It reads the `TimeAttendance`/`Attendance` sheet and uses `BulkInsertAsync`. Uploading the same payroll again replaces its rows. |
| 4 Export | `GET /api/payroll/{payrollNo}/export` returns one workbook with sheet 1 `PAYREG` and sheet 2 `OTR`, each filtered by `PAYROLL #`. |

## Intermediate level

`GET /api/payroll/{payrollNo}/overtime` returns an Excel file with EMPLOYEE ID #, LAST NAME, FIRST NAME, ATT DEDUCTION, OVERTIME.

The calculation is `Services/OvertimeCalculator.cs`. It is the Calculator sheet and PAYREG columns M and N written as LINQ:

- Hourly rate = `MonthlySalary x 12 / 261 / 8`. Daily rate = `MonthlySalary x 12 / 261` (the "no 8 divisor" columns).
- Line amount = rate x premium rate x hours (or days), rounded to 2 decimals.
- ATT DEDUCTION = `-(tardy + undertime + absent + LWOP)`. VL, SL and other leave are paid, so they are not deducted.
- OVERTIME = sum of night-differential and every OT line (Calculator columns V to CD).
- REG DAYS WRK is income only when the pay type is Daily, so it is in neither total.

Premium rates live in the `OtRate` table (Calculator row 8), keyed by the `TimeAttendance` property.

**Check:** with the Attendance sheet uploaded as payroll 61, the API matches PAYREG columns M and N for all 91 employees.

## Assumptions and things found in the workbook

- **EmpMaster "DAILY RATE" is the monthly salary** (it equals Calculator column D), so the column is stored as `MonthlySalary`. `EmpMaster` is an extra table, which the exam allows.
- **Calculator!AX8 = 185.9** is a typo. Its neighbours follow rate x 1.1 (1.69 x 1.1 = 1.859), so the seed uses 1.859. No row in the data uses it, so no result changes.
- **OTREG disagrees with PAYREG for 19 employees** (for example 85403: OTREG 2,820.58, PAYREG 2,876.56). OTREG lacks the NP rows, so the Calculator is treated as the source of truth.
- Test 4 says "rename sheet 1 to OTR" for the second sheet. The sheet is named `OTR` as written.
- `PAYREG` has two `MONTHLY SALARY RATE` columns, so the second is stored as `MONTHLY SALARY RATE 2`.
- Placeholder cells such as `"  -  "` are read as null.
- `data/Book1.xlsx` holds the sheets copied out of the exam workbook (EmpMaster, Attendance, Calculator, OTREG, PAYREG), as values without formulas. It is the file to upload in step 1 of the Swagger test. This repository is private.
