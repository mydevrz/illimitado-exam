using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PayrollApi;
using PayrollApi.Services;

const string XlsxType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PayrollDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<ExcelService>();
builder.Services.AddScoped<OvertimeCalculator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => o.SwaggerDoc("v1", new OpenApiInfo
{
    Title = "Illimitado Payroll API",
    Version = "v1",
    Description = """
        **How to test (in this order)**

        1. **Upload** `data/Book1.xlsx` with `payrollNo = 61`. The response should be `{"payrollNo":61,"inserted":91}`.
        2. **Overtime** with `payrollNo = 61`. Download the Excel file and compare ATT DEDUCTION and OVERTIME with PAYREG columns M and N of the workbook.
        3. **Export** with `payrollNo = 61`. The workbook has 2 sheets, `PAYREG` and `OTR`, with the seeded rows.

        The tables and seed data are created by the migration when the API starts.
        """
}));

var app = builder.Build();

// Applies the migration (tables + seed data) on start-up. `dotnet ef database update` does the same.
using (var scope = app.Services.CreateScope())
    await scope.ServiceProvider.GetRequiredService<PayrollDbContext>().Database.MigrateAsync();

app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

var api = app.MapGroup("/api");

// Test 3: upload an .xlsx into TimeAttendance (BulkExtensions).
api.MapPost("/timeattendance/upload", async (IFormFile file, int payrollNo, ExcelService excel, CancellationToken ct) =>
{
    await using var stream = file.OpenReadStream();
    var count = await excel.UploadTimeAttendanceAsync(stream, payrollNo, ct);
    return Results.Ok(new { payrollNo, inserted = count });
}).WithOpenApi(op =>
{
    op.Summary = "Step 1. Upload attendance to the TimeAttendance table";
    op.Description = """
        Reads an Excel file and bulk inserts its attendance rows into **TimeAttendance** (EFCore.BulkExtensions).

        **To test:** click *Try it out*, set `payrollNo` to `61`, choose `data/Book1.xlsx` as `file`, then *Execute*.
        **Expected:** `200` with `{"payrollNo":61,"inserted":91}`.

        The sheet named `TimeAttendance` or `Attendance` is used (otherwise the first sheet). Every row gets the given `payrollNo`.
        Uploading the same `payrollNo` again replaces its rows, it does not duplicate them.
        """;
    op.Parameters.First(p => p.Name == "payrollNo").Description = "Payroll # to stamp on the uploaded rows. Use 61.";
    return op;
});

// Test 4: 1 workbook, 2 sheets (PAYREG, OTR), filtered by Payroll #.
api.MapGet("/payroll/{payrollNo:int}/export", async (int payrollNo, ExcelService excel, CancellationToken ct) =>
    Results.File(await excel.ExportPayrollAsync(payrollNo, ct), XlsxType, $"PAYREG_OTR_{payrollNo}.xlsx"))
.WithOpenApi(op =>
{
    op.Summary = "Step 3. Export PAYREG and OTR to one Excel workbook";
    op.Description = """
        Returns one workbook with two sheets, both filtered by `PAYROLL #`:
        sheet 1 **PAYREG** (rows of PAYREG) and sheet 2 **OTR** (rows of OTREG).

        **To test:** click *Try it out*, set `payrollNo` to `61`, *Execute*, then *Download file* and open it in Excel.
        **Expected:** 2 sheets, 3 seeded rows each. A payroll # with no seeded rows gives sheets with only the header row.
        """;
    op.Parameters.First(p => p.Name == "payrollNo").Description = "Payroll # to filter by. Seed data is payroll 61.";
    return op;
});

// Intermediate: ATT DEDUCTION and OVERTIME per employee, exported to Excel.
api.MapGet("/payroll/{payrollNo:int}/overtime", async (int payrollNo, OvertimeCalculator calc, CancellationToken ct) =>
    Results.File(ExcelService.ExportOvertime(await calc.ComputeAsync(payrollNo, ct)), XlsxType, $"OTREG_{payrollNo}.xlsx"))
.WithOpenApi(op =>
{
    op.Summary = "Step 2. Calculate ATT DEDUCTION and OVERTIME and export to Excel";
    op.Description = """
        Calculates the amounts from the uploaded **TimeAttendance** rows and **EmpMaster** salaries (Calculator sheet logic, in `OvertimeCalculator`),
        and returns an Excel file with EMPLOYEE ID #, LAST NAME, FIRST NAME, ATT DEDUCTION and OVERTIME.

        **Upload first (step 1),** otherwise the file has only the header row.

        **To test:** click *Try it out*, set `payrollNo` to `61`, *Execute*, then *Download file*.
        **Expected:** 91 employees. For example ALBANO (84047) has ATT DEDUCTION `-1,051.12` and OVERTIME `988.47`,
        which matches PAYREG columns M and N of the workbook.
        """;
    op.Parameters.First(p => p.Name == "payrollNo").Description = "Payroll # whose attendance is calculated. Use 61 after the upload.";
    return op;
});

app.Run();
