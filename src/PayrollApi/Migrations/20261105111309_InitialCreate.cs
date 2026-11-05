using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PayrollApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    FileStatus = table.Column<string>(type: "text", nullable: true),
                    TaxStatus = table.Column<string>(type: "text", nullable: true),
                    MonthlySalary = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtRate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    PremiumRate = table.Column<decimal>(type: "numeric(10,4)", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtRate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OTREG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PAYROLL = table.Column<int>(name: "PAYROLL #", type: "integer", nullable: true),
                    PAYDATE = table.Column<DateTime>(name: "PAY DATE", type: "date", nullable: true),
                    PAYCODE = table.Column<string>(name: "PAY CODE", type: "text", nullable: true),
                    EMPLOYEEID = table.Column<int>(name: "EMPLOYEE ID#", type: "integer", nullable: true),
                    LASTNAME = table.Column<string>(name: "LAST NAME", type: "text", nullable: true),
                    FIRSTNAME = table.Column<string>(name: "FIRST NAME", type: "text", nullable: true),
                    FILESTATUS = table.Column<string>(name: "FILE STATUS", type: "text", nullable: true),
                    OTCODE = table.Column<string>(name: "OT CODE", type: "text", nullable: true),
                    DATE = table.Column<DateTime>(type: "date", nullable: true),
                    COSTCENTER = table.Column<int>(name: "COST CENTER", type: "integer", nullable: true),
                    OTRATE = table.Column<decimal>(name: "OT RATE", type: "numeric(18,2)", nullable: true),
                    OTHOURS = table.Column<decimal>(name: "OT HOURS", type: "numeric(18,2)", nullable: true),
                    OTMINUTES = table.Column<decimal>(name: "OT MINUTES", type: "numeric(18,2)", nullable: true),
                    OTAMOUNT = table.Column<decimal>(name: "OT AMOUNT", type: "numeric(18,2)", nullable: true),
                    OTNPHOURS = table.Column<decimal>(name: "OT NP HOURS", type: "numeric(18,2)", nullable: true),
                    OTNPMINUTES = table.Column<decimal>(name: "OT NP MINUTES", type: "numeric(18,2)", nullable: true),
                    OTNPAMOUNT = table.Column<decimal>(name: "OT NP AMOUNT", type: "numeric(18,2)", nullable: true),
                    OTNP2HOURS = table.Column<decimal>(name: "OT NP2 HOURS", type: "numeric(18,2)", nullable: true),
                    OTNP2MINUTES = table.Column<decimal>(name: "OT NP2 MINUTES", type: "numeric(18,2)", nullable: true),
                    OTNP2AMOUNT = table.Column<decimal>(name: "OT NP2 AMOUNT", type: "numeric(18,2)", nullable: true),
                    OTANDNPAMOUNT = table.Column<decimal>(name: "OT AND NP AMOUNT", type: "numeric(18,2)", nullable: true),
                    RECURSTART = table.Column<DateTime>(name: "RECUR START", type: "date", nullable: true),
                    RECUREND = table.Column<DateTime>(name: "RECUR END", type: "date", nullable: true),
                    FREQ = table.Column<string>(type: "text", nullable: true),
                    REMARKS = table.Column<string>(type: "text", nullable: true),
                    SYSTEMOTHOURS = table.Column<decimal>(name: "SYSTEM OT HOURS", type: "numeric(18,2)", nullable: true),
                    SYSTEMOTTIME = table.Column<string>(name: "SYSTEM OT TIME", type: "text", nullable: true),
                    SYSTEMNPHOURS = table.Column<decimal>(name: "SYSTEM NP HOURS", type: "numeric(18,2)", nullable: true),
                    SYSTEMNPTIME = table.Column<string>(name: "SYSTEM NP TIME", type: "text", nullable: true),
                    FROM = table.Column<DateTime>(type: "date", nullable: true),
                    TO = table.Column<DateTime>(type: "date", nullable: true),
                    JECOSTCENTER = table.Column<int>(name: "JE COST CENTER", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTREG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PAYREG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PAYROLL = table.Column<int>(name: "PAYROLL #", type: "integer", nullable: true),
                    PAYDATE = table.Column<DateTime>(name: "PAY DATE", type: "date", nullable: true),
                    PAYCODE = table.Column<string>(name: "PAY CODE", type: "text", nullable: true),
                    EMPLOYEEID = table.Column<int>(name: "EMPLOYEE ID#", type: "integer", nullable: true),
                    LASTNAME = table.Column<string>(name: "LAST NAME", type: "text", nullable: true),
                    FIRSTNAME = table.Column<string>(name: "FIRST NAME", type: "text", nullable: true),
                    FILESTATUS = table.Column<string>(name: "FILE STATUS", type: "text", nullable: true),
                    TAXSTATUS = table.Column<string>(name: "TAX STATUS", type: "text", nullable: true),
                    MONTHLYSALARYRATE = table.Column<decimal>(name: "MONTHLY SALARY RATE", type: "numeric(18,2)", nullable: true),
                    BASICSALARY = table.Column<decimal>(name: "BASIC SALARY", type: "numeric(18,2)", nullable: true),
                    DAILYRATE = table.Column<decimal>(name: "DAILY RATE", type: "numeric(18,2)", nullable: true),
                    SALARYRATETYPE = table.Column<string>(name: "SALARY RATE TYPE", type: "text", nullable: true),
                    ATTDEDUCTION = table.Column<decimal>(name: "ATT DEDUCTION", type: "numeric(18,2)", nullable: true),
                    OVERTIME = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    OTHERTXINCOME = table.Column<decimal>(name: "OTHER TX INCOME", type: "numeric(18,2)", nullable: true),
                    ADJUSTMENTS = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    GROSSINCOME = table.Column<decimal>(name: "GROSS INCOME", type: "numeric(18,2)", nullable: true),
                    EMPLOYEESSS = table.Column<decimal>(name: "EMPLOYEE SSS", type: "numeric(18,2)", nullable: true),
                    EMPLOYEEMCR = table.Column<decimal>(name: "EMPLOYEE MCR", type: "numeric(18,2)", nullable: true),
                    EMPLOYEEPAGIBIG = table.Column<decimal>(name: "EMPLOYEE PAG-IBIG", type: "numeric(18,2)", nullable: true),
                    TAXABLEINCOME = table.Column<decimal>(name: "TAXABLE INCOME", type: "numeric(18,2)", nullable: true),
                    WITHOLDINGTAX = table.Column<decimal>(name: "WITHOLDING TAX", type: "numeric(18,2)", nullable: true),
                    NETSALARYAFTERTAX = table.Column<decimal>(name: "NET SALARY AFTER TAX", type: "numeric(18,2)", nullable: true),
                    OTHERNTXINCOME = table.Column<decimal>(name: "OTHER NTX INCOME", type: "numeric(18,2)", nullable: true),
                    LOANPAYMENTS = table.Column<decimal>(name: "LOAN PAYMENTS", type: "numeric(18,2)", nullable: true),
                    DEDUCTIONS = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    NETSALARY = table.Column<decimal>(name: "NET SALARY", type: "numeric(18,2)", nullable: true),
                    EMPLOYERSSS = table.Column<decimal>(name: "EMPLOYER SSS", type: "numeric(18,2)", nullable: true),
                    EMPLOYERMCR = table.Column<decimal>(name: "EMPLOYER MCR", type: "numeric(18,2)", nullable: true),
                    EMPLOYEREC = table.Column<decimal>(name: "EMPLOYER EC", type: "numeric(18,2)", nullable: true),
                    EMPLOYERPAGIBIG = table.Column<decimal>(name: "EMPLOYER PAG-IBIG", type: "numeric(18,2)", nullable: true),
                    PAYROLLCOST = table.Column<decimal>(name: "PAYROLL COST", type: "numeric(18,2)", nullable: true),
                    PREVIOUSYTDGROSS = table.Column<decimal>(name: "PREVIOUS YTD GROSS", type: "numeric(18,2)", nullable: true),
                    PREVIOUSYTDWITHOLDING = table.Column<decimal>(name: "PREVIOUS YTD WITHOLDING", type: "numeric(18,2)", nullable: true),
                    PREVIOUSYTDSSS = table.Column<decimal>(name: "PREVIOUS YTD SSS", type: "numeric(18,2)", nullable: true),
                    PREVIOUSYTDMCR = table.Column<decimal>(name: "PREVIOUS YTD MCR", type: "numeric(18,2)", nullable: true),
                    PREVIOUSYTDPAGIBIG = table.Column<decimal>(name: "PREVIOUS YTD PAG-IBIG", type: "numeric(18,2)", nullable: true),
                    PREVIOUSYTDBON13THNT = table.Column<decimal>(name: "PREVIOUS YTD BON/13TH NT", type: "numeric(18,2)", nullable: true),
                    PREVIOUSYTDBON13THTX = table.Column<decimal>(name: "PREVIOUS YTD BON/13TH TX", type: "numeric(18,2)", nullable: true),
                    PAYMENTTYPE = table.Column<string>(name: "PAYMENT TYPE", type: "text", nullable: true),
                    BANKACCT = table.Column<string>(name: "BANK ACCT#", type: "text", nullable: true),
                    BANKNAME = table.Column<string>(name: "BANK NAME", type: "text", nullable: true),
                    COMMENTFIELD = table.Column<string>(name: "COMMENT FIELD", type: "text", nullable: true),
                    ERRORFIELD = table.Column<string>(name: "ERROR FIELD", type: "text", nullable: true),
                    DATEEMPLOYED = table.Column<DateTime>(name: "DATE EMPLOYED", type: "date", nullable: true),
                    DATETERMINATED = table.Column<DateTime>(name: "DATE TERMINATED", type: "date", nullable: true),
                    COSTCENTER = table.Column<int>(name: "COST CENTER", type: "integer", nullable: true),
                    CURRENCY = table.Column<string>(type: "text", nullable: true),
                    EXCHANGERATE = table.Column<decimal>(name: "EXCHANGE RATE", type: "numeric(18,2)", nullable: true),
                    TAXTABLE = table.Column<string>(name: "TAX TABLE", type: "text", nullable: true),
                    PAYMENTFREQ = table.Column<string>(name: "PAYMENT FREQ", type: "text", nullable: true),
                    MTDGROSS = table.Column<decimal>(name: "MTD GROSS", type: "numeric(18,2)", nullable: true),
                    MTDBASIC = table.Column<decimal>(name: "MTD BASIC", type: "numeric(18,2)", nullable: true),
                    MTDSSSEMPLOYEE = table.Column<decimal>(name: "MTD SSS EMPLOYEE", type: "numeric(18,2)", nullable: true),
                    MTDMCREMPLOYEE = table.Column<decimal>(name: "MTD MCR EMPLOYEE", type: "numeric(18,2)", nullable: true),
                    MTDPAGIBIGEMPLOYEE = table.Column<decimal>(name: "MTD PAG-IBIG EMPLOYEE", type: "numeric(18,2)", nullable: true),
                    MTDSSSEMPLOYER = table.Column<decimal>(name: "MTD SSS EMPLOYER", type: "numeric(18,2)", nullable: true),
                    MTDMCREMPLOYER = table.Column<decimal>(name: "MTD MCR EMPLOYER", type: "numeric(18,2)", nullable: true),
                    MTDECEMPLOYER = table.Column<decimal>(name: "MTD EC EMPLOYER", type: "numeric(18,2)", nullable: true),
                    MTDPAGIBIGEMPLOYER = table.Column<decimal>(name: "MTD PAG-IBIG EMPLOYER", type: "numeric(18,2)", nullable: true),
                    MTDWHTAX = table.Column<decimal>(name: "MTD WH TAX", type: "numeric(18,2)", nullable: true),
                    MONTHLYSALARYRATE2 = table.Column<decimal>(name: "MONTHLY SALARY RATE 2", type: "numeric(18,2)", nullable: true),
                    MONTHLYALLOW = table.Column<decimal>(name: "MONTHLY ALLOW", type: "numeric(18,2)", nullable: true),
                    MTDNTX = table.Column<decimal>(name: "MTD NTX", type: "numeric(18,2)", nullable: true),
                    FROM = table.Column<DateTime>(type: "date", nullable: true),
                    TO = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYREG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PAYROLL = table.Column<int>(name: "PAYROLL #", type: "integer", nullable: true),
                    EMPID = table.Column<int>(name: "EMP ID#", type: "integer", nullable: true),
                    LASTNAME = table.Column<string>(name: "LAST NAME", type: "text", nullable: true),
                    FIRSTNAME = table.Column<string>(name: "FIRST NAME", type: "text", nullable: true),
                    REGDAYSWRK = table.Column<decimal>(name: "REG DAYS WRK", type: "numeric(18,2)", nullable: true),
                    TARDYHRS = table.Column<decimal>(name: "TARDY HRS", type: "numeric(18,2)", nullable: true),
                    UNDERTIMEHRS = table.Column<decimal>(name: "UNDERTIME HRS", type: "numeric(18,2)", nullable: true),
                    ABSENTDAYS = table.Column<decimal>(name: "ABSENT DAYS", type: "numeric(18,2)", nullable: true),
                    LWOPDAYS = table.Column<decimal>(name: "LWOP DAYS", type: "numeric(18,2)", nullable: true),
                    VLDAYS = table.Column<decimal>(name: "VL DAYS", type: "numeric(18,2)", nullable: true),
                    SLDAYS = table.Column<decimal>(name: "SL DAYS", type: "numeric(18,2)", nullable: true),
                    OTHERLVDAYS = table.Column<decimal>(name: "OTHER LV DAYS", type: "numeric(18,2)", nullable: true),
                    NITEDIFF10 = table.Column<decimal>(name: "NITE-DIFF 10%", type: "numeric(18,2)", nullable: true),
                    REGULAROT = table.Column<decimal>(name: "REGULAR-OT", type: "numeric(18,2)", nullable: true),
                    REGOTNPHRS10 = table.Column<decimal>(name: "REG-OT (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    LEGALHOLOT = table.Column<decimal>(name: "LEGAL HOL OT", type: "numeric(18,2)", nullable: true),
                    LEGALHOLOTNPHRS10 = table.Column<decimal>(name: "LEGAL HOL OT (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    LEGALHOLOT8HRS = table.Column<decimal>(name: "LEGAL HOL OT > 8HRS", type: "numeric(18,2)", nullable: true),
                    LEGALHOLOT8NPHRS10 = table.Column<decimal>(name: "LEGAL HOL OT >8 (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    LEGALHOLRD = table.Column<decimal>(name: "LEGAL HOL RD", type: "numeric(18,2)", nullable: true),
                    LEGALHOLRDNPHRS10 = table.Column<decimal>(name: "LEGAL HOL RD (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    LEGALHOLRD8HRS = table.Column<decimal>(name: "LEGAL HOL RD >8HRS", type: "numeric(18,2)", nullable: true),
                    LEGALHOLRD8NPHRS10 = table.Column<decimal>(name: "LEGAL HOL RD >8 (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    SPECLHOLOT = table.Column<decimal>(name: "SPECL HOL OT", type: "numeric(18,2)", nullable: true),
                    SPECLHOLOTNPHRS10 = table.Column<decimal>(name: "SPECL HOL OT (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    SPECLHOLIDAYOT8 = table.Column<decimal>(name: "SPECL HOLIDAY OT >8", type: "numeric(18,2)", nullable: true),
                    SPECLHOLOT8NPHRS10 = table.Column<decimal>(name: "SPECL HOL OT >8 (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    SPECIALHOLIDAYRD = table.Column<decimal>(name: "SPECIAL HOLIDAY RD", type: "numeric(18,2)", nullable: true),
                    SPECIALHOLRDNPHRS10 = table.Column<decimal>(name: "SPECIAL HOL RD (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    SPECLHOLIDAYONRD8HRS = table.Column<decimal>(name: "SPECL HOLIDAY ON RD > 8HRS", type: "numeric(18,2)", nullable: true),
                    SPECLHOLRD8NPHRS10 = table.Column<decimal>(name: "SPECL HOL RD > 8 (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    RESTDAYOT = table.Column<decimal>(name: "REST DAY OT", type: "numeric(18,2)", nullable: true),
                    RESTDAYOTNPHRS10 = table.Column<decimal>(name: "REST DAY OT (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    RESTDAYOT8HRS = table.Column<decimal>(name: "REST DAY OT > 8HRS", type: "numeric(18,2)", nullable: true),
                    RESTDAYOT8NPHRS10 = table.Column<decimal>(name: "REST DAY OT > 8 (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    DOUBLEHOLIDAYOT = table.Column<decimal>(name: "DOUBLE HOLIDAY OT", type: "numeric(18,2)", nullable: true),
                    DOUBLEHOLIDAYOTNPHRS10 = table.Column<decimal>(name: "DOUBLE HOLIDAY OT (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    DOUBLEHOLIDAYOT8HRS = table.Column<decimal>(name: "DOUBLE HOLIDAY OT > 8HRS", type: "numeric(18,2)", nullable: true),
                    DOUBLEHOLIDAYOT8NPHRS10 = table.Column<decimal>(name: "DOUBLE HOLIDAY OT > 8 (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    DOUBLEHOLIDAYRD = table.Column<decimal>(name: "DOUBLE HOLIDAY RD", type: "numeric(18,2)", nullable: true),
                    DOUBLEHOLRDNPHRS10 = table.Column<decimal>(name: "DOUBLE HOL RD (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    DOUBLEHOLONRD8HRS = table.Column<decimal>(name: "DOUBLE HOL ON RD > 8HRS", type: "numeric(18,2)", nullable: true),
                    DOUBLEHOLRD8NPHRS10 = table.Column<decimal>(name: "DOUBLE HOL RD > 8 (NP HRS 10%)", type: "numeric(18,2)", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAttendance", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmpMaster",
                columns: new[] { "Id", "EmployeeId", "FileStatus", "FirstName", "LastName", "MonthlySalary", "TaxStatus" },
                values: new object[,]
                {
                    { 1, 85403, "EMPLOYEE", "JESSEN", "ABUY", 21292.0m, "S" },
                    { 2, 85230, "EMPLOYEE", "SHARDAINE", "AGNOTE", 40000.0m, "S" },
                    { 3, 84024, "EMPLOYEE", "JETHRO", "AGUILAR", 28159.0m, "ME1" },
                    { 4, 84047, "EMPLOYEE", "MARK LESTER", "ALBANO", 20783.47m, "ME1" },
                    { 5, 85442, "EMPLOYEE", "GRACE ANNE", "ALEJO", 37240.0m, "S" },
                    { 6, 84347, "EMPLOYEE", "KRYSTAL ANGELA", "ARGUELLES", 49250.0m, "S" },
                    { 7, 85438, "EMPLOYEE", "MARIEL ANGELICA", "AZOGUE", 21292.0m, "ME2" },
                    { 8, 84426, "EMPLOYEE", "MERIELYN", "BAGUIO", 25298.01m, "S" },
                    { 9, 85242, "EMPLOYEE", "OSMOND", "BANDOQUILLO", 23500.0m, "S1" },
                    { 10, 84058, "EMPLOYEE", "KAIXER", "BASE", 21255.7m, "S" },
                    { 11, 85416, "EMPLOYEE", "DANICA MAE", "BAWA", 25500.0m, "S" },
                    { 12, 85228, "EMPLOYEE", "AILAH", "BERNABE", 26500.0m, "S" },
                    { 13, 85294, "EMPLOYEE", "CARLO ANTONIO", "BORA", 14000.0m, "S" },
                    { 14, 85437, "EMPLOYEE", "ELVIN MARK", "BRAVO", 51500.0m, "S" },
                    { 15, 84349, "EMPLOYEE", "CARL MICHAEL", "CARRANZA", 26750.0m, "S" },
                    { 16, 84390, "EMPLOYEE", "MARY ANN", "CASTILLO", 27202.79m, "S" },
                    { 17, 84122, "EMPLOYEE", "JOANNA MAE", "CO", 49634.7m, "S2" },
                    { 18, 84344, "EMPLOYEE", "LOUWEL", "COLASITO", 34649.63m, "S" },
                    { 19, 84275, "EMPLOYEE", "SANDRA CAMIL", "CONSOLACION", 33977.7m, "S" },
                    { 20, 84713, "EMPLOYEE", "JOHN PAULO", "CORDERO", 28890.0m, "ME" },
                    { 21, 84290, "EMPLOYEE", "KRISTINE LORRAINE", "CRUZ", 29953.15m, "S1" },
                    { 22, 84668, "EMPLOYEE", "PATRICK BENJ", "CUAYCONG", 23112.0m, "S2" },
                    { 23, 85548, "EMPLOYEE", "RANNIE", "DAEL", 46550.0m, "S" },
                    { 24, 84457, "EMPLOYEE", "JOAN", "DANGANAN", 28159.0m, "S" },
                    { 25, 84354, "EMPLOYEE", "ANNELIE", "DE JESUS", 31417.5m, "S" },
                    { 26, 84746, "EMPLOYEE", "LORENZO VICENTE", "DE JUAN", 28159.0m, "S" },
                    { 27, 84514, "EMPLOYEE", "ARCHIVAL", "DELA CRUZ", 26209.01m, "S2" },
                    { 28, 84414, "EMPLOYEE", "MA. TERESA", "DELA CRUZ", 35198.0m, "S" },
                    { 29, 85065, "EMPLOYEE", "JOSEPH RAY", "DELA CRUZ", 28862.98m, "ME4" },
                    { 30, 84392, "EMPLOYEE", "ELEAZAR", "DELOS SANTOS", 40219.47m, "S" },
                    { 31, 85252, "EMPLOYEE", "PAULA ANGELA", "DIMALANTA", 46500.0m, "S" },
                    { 32, 85092, "EMPLOYEE", "REMIGIO", "DIZON", 14000.0m, "S" },
                    { 33, 85207, "EMPLOYEE", "JEZREEL", "ENCINAS", 18500.0m, "S" },
                    { 34, 84654, "EMPLOYEE", "IRENE", "ENERIO", 28159.0m, "S" },
                    { 35, 84429, "EMPLOYEE", "MC ALI", "ESPARTERO", 31201.2m, "S" },
                    { 36, 85017, "EMPLOYEE", "JOSEPH ALBERT", "EVIDENTE", 35360.0m, "S" },
                    { 37, 85066, "EMPLOYEE", "AARON JOHN", "FAJARDO", 28769.11m, "S" },
                    { 38, 84206, "EMPLOYEE", "KAREN JOY", "FERNANDO", 26694.36m, "S1" },
                    { 39, 84434, "EMPLOYEE", "MARY ANN", "FLORES", 25465.44m, "ME3" },
                    { 40, 85123, "EMPLOYEE", "MA. EVELIA", "FLORES", 28159.0m, "ME" },
                    { 41, 67016, "EMPLOYEE", "JOY", "FRANCIA", 73882.82m, "S" },
                    { 42, 84456, "EMPLOYEE", "JOY ABIGAIL", "GALVEZ", 30411.72m, "S" },
                    { 43, 67008, "EMPLOYEE", "ANNELIE", "GARCIA", 49687.17m, "S" },
                    { 44, 84205, "EMPLOYEE", "CHAMAINE JIEBEL", "GARCIA", 37240.28m, "S" },
                    { 45, 84383, "EMPLOYEE", "ROMMEL", "GASPAR", 34649.63m, "ME1" },
                    { 46, 85377, "EMPLOYEE", "BRUCE", "GIMENO", 46500.0m, "ME3" },
                    { 47, 84577, "EMPLOYEE", "RAMONCITO RAFAEL", "GUTIERREZ", 18515.0m, "S" },
                    { 48, 84143, "EMPLOYEE", "OSET", "JAYME", 29848.54m, "S1" },
                    { 49, 84431, "EMPLOYEE", "ANDREW LOUIE", "LAZO", 49250.0m, "ME3" },
                    { 50, 84427, "EMPLOYEE", "RICA JEAN", "LIBRAMONTE", 35198.0m, "S2" },
                    { 51, 84400, "EMPLOYEE", "SAMUEL JR", "LOPEZ", 32617.76m, "S1" },
                    { 52, 85460, "EMPLOYEE", "JUDY", "LOYOLA", 21500.0m, "S" },
                    { 53, 85205, "EMPLOYEE", "JANETTE", "MACAPAAR", 16100.0m, "S" },
                    { 54, 85166, "EMPLOYEE", "ADZMAN", "MAGANO", 40000.0m, "S" },
                    { 55, 85206, "EMPLOYEE", "CLARKE", "MAGNO", 22000.0m, "S" },
                    { 56, 84419, "EMPLOYEE", "KREESA REY", "MAHUSAY", 31201.2m, "S" },
                    { 57, 85067, "EMPLOYEE", "MARIA CHRISTINA", "MAMANGUN", 37240.28m, "S" },
                    { 58, 84247, "EMPLOYEE", "APRIL JOY", "MASA", 26077.59m, "ME" },
                    { 59, 85401, "EMPLOYEE", "EDGAR", "MAXIMO", 16100.0m, "S" },
                    { 60, 84531, "EMPLOYEE", "CARL DANJA", "MENESES", 34325.8m, "S" },
                    { 61, 85086, "EMPLOYEE", "AIMIE", "MORALES", 28581.39m, "S" },
                    { 62, 85378, "EMPLOYEE", "BENEDICT", "NADAL JR.", 51500.0m, "S" },
                    { 63, 84627, "EMPLOYEE", "GLENN", "OCAMPO", 23704.0m, "S" },
                    { 64, 67022, "EMPLOYEE", "JANETH", "PADUA", 55860.42m, "S" },
                    { 65, 67012, "EMPLOYEE", "JANE REA", "PARCO", 65565.26m, "S" },
                    { 66, 84064, "EMPLOYEE", "ROSARIE ANNE", "QUEVEDO", 30411.72m, "S1" },
                    { 67, 84068, "EMPLOYEE", "TEREZE ANN KRIZIA", "QUINO", 28159.0m, "S" },
                    { 68, 85360, "EMPLOYEE", "LILY JANE", "RAGASA", 16100.0m, "S" },
                    { 69, 84649, "EMPLOYEE", "PAUL ADRIAN", "RAMIREZ", 22669.02m, "S1" },
                    { 70, 85069, "EMPLOYEE", "JOYCE", "RAMOS", 16346.67m, "S" },
                    { 71, 84283, "EMPLOYEE", "KATHERINA", "RAYOS", 22850.0m, "S" },
                    { 72, 85402, "EMPLOYEE", "CHER JASMINE", "REYES", 16100.0m, "S" },
                    { 73, 84272, "EMPLOYEE", "ANNA KATRINA", "RIVERA III", 34716.15m, "ME1" },
                    { 74, 84438, "EMPLOYEE", "CRISTOPHER MARTIN", "RUMBAUA", 29775.44m, "S" },
                    { 75, 84057, "EMPLOYEE", "GENEVAVE", "SABANDAL", 20783.47m, "S1" },
                    { 76, 84458, "EMPLOYEE", "CLARISSA", "SANTIAGO", 22773.96m, "ME" },
                    { 77, 84279, "EMPLOYEE", "DAISY", "SANTOS", 25173.24m, "S" },
                    { 78, 67065, "EMPLOYEE", "GRETCHEN ELIZA", "SANTOS", 22642.79m, "ME2" },
                    { 79, 84711, "EMPLOYEE", "RICA ZANETA", "SEGUBIENCE", 34649.63m, "ME" },
                    { 80, 85042, "EMPLOYEE", "SHERYL", "SERVAS", 50762.0m, "S" },
                    { 81, 84821, "EMPLOYEE", "JAMES ALFRED", "SOMBILONA", 47700.0m, "S" },
                    { 82, 84666, "EMPLOYEE", "ALLAN RAYMOND", "TERCERO", 17412.75m, "S" },
                    { 83, 85429, "EMPLOYEE", "MARK JOHN", "TIAMA", 16100.0m, "S" },
                    { 84, 84714, "EMPLOYEE", "CLYDE JASPER", "TIMTIM", 34325.8m, "ME" },
                    { 85, 84613, "EMPLOYEE", "MAUREEN MAE", "TIMTIMAN", 28159.0m, "S1" },
                    { 86, 84345, "EMPLOYEE", "NOEL", "TOPACIO", 30411.72m, "ME1" },
                    { 87, 84040, "EMPLOYEE", "MARIA ERIKA", "VASQUEZ", 20405.58m, "S" },
                    { 88, 85399, "EMPLOYEE", "JOVIE", "VILLANUEVA", 26500.0m, "S1" },
                    { 89, 84638, "EMPLOYEE", "JOAN", "VILLARUZ", 22572.0m, "ME1" },
                    { 90, 85143, "EMPLOYEE", "MA. ERIKA GRACE", "YGOT", 21000.0m, "S" },
                    { 91, 84195, "EMPLOYEE", "ENZO MIGUEL", "ZAMORA", 22578.47m, "S" }
                });

            migrationBuilder.InsertData(
                table: "OTREG",
                columns: new[] { "Id", "COST CENTER", "DATE", "EMPLOYEE ID#", "FILE STATUS", "FIRST NAME", "FREQ", "FROM", "JE COST CENTER", "LAST NAME", "OT AMOUNT", "OT AND NP AMOUNT", "OT CODE", "OT HOURS", "OT MINUTES", "OT NP2 AMOUNT", "OT NP2 HOURS", "OT NP2 MINUTES", "OT NP AMOUNT", "OT NP HOURS", "OT NP MINUTES", "OT RATE", "PAY CODE", "PAY DATE", "PAYROLL #", "RECUR END", "RECUR START", "REMARKS", "SYSTEM NP HOURS", "SYSTEM NP TIME", "SYSTEM OT HOURS", "SYSTEM OT TIME", "TO" },
                values: new object[,]
                {
                    { 1, 5035, new DateTime(2020, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 67008, "EMPLOYEE", "ANNELIE", null, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5035, "GARCIA", 3426.7m, 3426.7m, "NITE-DIFF", 80.0m, null, 0.0m, 0.0m, null, 0.0m, 0.0m, null, 0.15m, "BROADSPIRE-SEMI", new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 61, null, null, "UPLOADED FROM EXCEL", 0.0m, "00000:00000", 80.0m, "00080:00000", new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 5035, new DateTime(2020, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 67008, "EMPLOYEE", "ANNELIE", null, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5035, "GARCIA", 1427.79m, 1427.79m, "REG-OT", 4.0m, null, 0.0m, 0.0m, null, 0.0m, 0.0m, null, 1.25m, "BROADSPIRE-SEMI", new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 61, null, null, "UPLOADED FROM EXCEL", 0.0m, "00000:00000", 4.0m, "00004:00000", new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 5035, new DateTime(2020, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 67008, "EMPLOYEE", "ANNELIE", null, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5035, "GARCIA", 0.0m, 214.17m, "REG-OT", 0.0m, null, 0.0m, 0.0m, null, 214.17m, 4.0m, null, 1.25m, "BROADSPIRE-SEMI", new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 61, null, null, "UPLOADED FROM EXCEL", 4.0m, "00004:00000", 0.0m, "00000:00000", new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OtRate",
                columns: new[] { "Id", "Category", "Description", "Key", "Note", "PremiumRate", "Unit" },
                values: new object[,]
                {
                    { 1, "Excluded", "REG DAYS WRK", "RegDaysWrk", null, 1m, "Days" },
                    { 2, "Deduction", "TARDY HRS", "TardyHrs", null, 1m, "Hours" },
                    { 3, "Deduction", "UNDERTIME HRS", "UndertimeHrs", null, 1m, "Hours" },
                    { 4, "Deduction", "ABSENT DAYS", "AbsentDays", null, 1m, "Days" },
                    { 5, "Deduction", "LWOP DAYS", "LwopDays", null, 1m, "Days" },
                    { 6, "Excluded", "VL DAYS", "VlDays", null, 1m, "Days" },
                    { 7, "Excluded", "SL DAYS", "SlDays", null, 1m, "Days" },
                    { 8, "Excluded", "OTHER LV DAYS", "OtherLvDays", null, 1m, "Days" },
                    { 9, "Overtime", "NITE-DIFF 10%", "NiteDiff10Pct", null, 0.15m, "Hours" },
                    { 10, "Overtime", "REGULAR-OT", "RegularOt", null, 1.25m, "Hours" },
                    { 11, "Overtime", "REG-OT (NP HRS 10%)", "RegOtNpHrs10Pct", null, 0.1875m, "Hours" },
                    { 12, "Overtime", "LEGAL HOL OT", "LegalHolOt", null, 1m, "Hours" },
                    { 13, "Overtime", "LEGAL HOL OT (NP HRS 10%)", "LegalHolOtNpHrs10Pct", null, 0.2m, "Hours" },
                    { 14, "Overtime", "LEGAL HOL OT > 8HRS", "LegalHolOtGt8hrs", null, 2.6m, "Hours" },
                    { 15, "Overtime", "LEGAL HOL OT >8 (NP HRS 10%)", "LegalHolOtGt8NpHrs10Pct", null, 2.86m, "Hours" },
                    { 16, "Overtime", "LEGAL HOL RD", "LegalHolRd", null, 2.6m, "Hours" },
                    { 17, "Overtime", "LEGAL HOL RD (NP HRS 10%)", "LegalHolRdNpHrs10Pct", null, 0.26m, "Hours" },
                    { 18, "Overtime", "LEGAL HOL RD >8HRS", "LegalHolRdGt8hrs", null, 3.38m, "Hours" },
                    { 19, "Overtime", "LEGAL HOL RD >8 (NP HRS 10%)", "LegalHolRdGt8NpHrs10Pct", null, 3.718m, "Hours" },
                    { 20, "Overtime", "SPECL HOL OT", "SpeclHolOt", null, 0.3m, "Hours" },
                    { 21, "Overtime", "SPECL HOL OT (NP HRS 10%)", "SpeclHolOtNpHrs10Pct", null, 0.13m, "Hours" },
                    { 22, "Overtime", "SPECL HOLIDAY OT >8", "SpeclHolidayOtGt8", null, 1.69m, "Hours" },
                    { 23, "Overtime", "SPECL HOL OT >8 (NP HRS 10%)", "SpeclHolOtGt8NpHrs10Pct", "Calculator!AX8 holds 185.9 (typo, pattern is 1.69 x 1.1 = 1.859)", 1.859m, "Hours" },
                    { 24, "Overtime", "SPECIAL HOLIDAY RD", "SpecialHolidayRd", null, 1.5m, "Hours" },
                    { 25, "Overtime", "SPECIAL HOL RD (NP HRS 10%)", "SpecialHolRdNpHrs10Pct", null, 0.15m, "Hours" },
                    { 26, "Overtime", "SPECL HOLIDAY ON RD > 8HRS", "SpeclHolidayOnRdGt8hrs", null, 1.95m, "Hours" },
                    { 27, "Overtime", "SPECL HOL RD > 8 (NP HRS 10%)", "SpeclHolRdGt8NpHrs10Pct", null, 2.145m, "Hours" },
                    { 28, "Overtime", "REST DAY OT", "RestDayOt", null, 1.3m, "Hours" },
                    { 29, "Overtime", "REST DAY OT (NP HRS 10%)", "RestDayOtNpHrs10Pct", null, 0.13m, "Hours" },
                    { 30, "Overtime", "REST DAY OT > 8HRS", "RestDayOtGt8hrs", null, 1.69m, "Hours" },
                    { 31, "Overtime", "REST DAY OT > 8 (NP HRS 10%)", "RestDayOtGt8NpHrs10Pct", null, 1.859m, "Hours" },
                    { 32, "Overtime", "DOUBLE HOLIDAY OT", "DoubleHolidayOt", null, 2m, "Hours" },
                    { 33, "Overtime", "DOUBLE HOLIDAY OT (NP HRS 10%)", "DoubleHolidayOtNpHrs10Pct", null, 0.3m, "Hours" },
                    { 34, "Overtime", "DOUBLE HOLIDAY OT > 8HRS", "DoubleHolidayOtGt8hrs", null, 3.9m, "Hours" },
                    { 35, "Overtime", "DOUBLE HOLIDAY OT > 8 (NP HRS 10%)", "DoubleHolidayOtGt8NpHrs10Pct", null, 4.29m, "Hours" },
                    { 36, "Overtime", "DOUBLE HOLIDAY RD", "DoubleHolidayRd", null, 3.9m, "Hours" },
                    { 37, "Overtime", "DOUBLE HOL RD (NP HRS 10%)", "DoubleHolRdNpHrs10Pct", null, 0.39m, "Hours" },
                    { 38, "Overtime", "DOUBLE HOL ON RD > 8HRS", "DoubleHolOnRdGt8hrs", null, 5.07m, "Hours" },
                    { 39, "Overtime", "DOUBLE HOL RD > 8 (NP HRS 10%)", "DoubleHolRdGt8NpHrs10Pct", null, 5.58m, "Hours" }
                });

            migrationBuilder.InsertData(
                table: "PAYREG",
                columns: new[] { "Id", "ADJUSTMENTS", "ATT DEDUCTION", "BANK ACCT#", "BANK NAME", "BASIC SALARY", "COMMENT FIELD", "COST CENTER", "CURRENCY", "DAILY RATE", "DATE EMPLOYED", "DATE TERMINATED", "DEDUCTIONS", "EMPLOYEE ID#", "EMPLOYEE MCR", "EMPLOYEE PAG-IBIG", "EMPLOYEE SSS", "EMPLOYER EC", "EMPLOYER MCR", "EMPLOYER PAG-IBIG", "EMPLOYER SSS", "ERROR FIELD", "EXCHANGE RATE", "FILE STATUS", "FIRST NAME", "FROM", "GROSS INCOME", "LAST NAME", "LOAN PAYMENTS", "MONTHLY ALLOW", "MONTHLY SALARY RATE", "MONTHLY SALARY RATE 2", "MTD BASIC", "MTD EC EMPLOYER", "MTD GROSS", "MTD MCR EMPLOYEE", "MTD MCR EMPLOYER", "MTD NTX", "MTD PAG-IBIG EMPLOYEE", "MTD PAG-IBIG EMPLOYER", "MTD SSS EMPLOYEE", "MTD SSS EMPLOYER", "MTD WH TAX", "NET SALARY", "NET SALARY AFTER TAX", "OTHER NTX INCOME", "OTHER TX INCOME", "OVERTIME", "PAY CODE", "PAY DATE", "PAYMENT FREQ", "PAYMENT TYPE", "PAYROLL COST", "PAYROLL #", "PREVIOUS YTD BON/13TH NT", "PREVIOUS YTD BON/13TH TX", "PREVIOUS YTD GROSS", "PREVIOUS YTD MCR", "PREVIOUS YTD PAG-IBIG", "PREVIOUS YTD SSS", "PREVIOUS YTD WITHOLDING", "SALARY RATE TYPE", "TAX STATUS", "TAX TABLE", "TAXABLE INCOME", "TO", "WITHOLDING TAX" },
                values: new object[,]
                {
                    { 1, 0.0m, null, "32170722", "SBC", 49687.17m, "4", 5035, "PESO", 2284.47m, new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.0m, 67008, 372.66m, 0.0m, 0.0m, 0.0m, 372.66m, 0.0m, 0.0m, null, 1.0m, "EMPLOYEE", "ANNELIE", new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 30287.25m, "GARCIA", 2312.07m, 0.0m, 49687.17m, 49687.17m, 24843.59m, 30.0m, 36299.79m, 372.65m, 372.65m, 2000.0m, 100.0m, 100.0m, 800.0m, 1600.0m, 5924.91m, 25040.62m, 25725.35m, 2000.0m, 375.0m, 5068.66m, "BROADSPIRE-SEMI", new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEMI-MONTHLY", "BANK", 32659.91m, 61, 12421.79m, 0.0m, 154464.3m, 1863.27m, 300.0m, 2400.0m, 24143.02m, "PER MONTH", "S", "SEMI-MONTHLY", null, new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4561.9m },
                    { 2, 0.0m, -56.52m, "32170977", "SBC", 65565.26m, "10", 5037, "PESO", 3014.49m, new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.0m, 67012, 408.26m, 0.0m, 0.0m, 0.0m, 408.26m, 0.0m, 0.0m, null, 1.0m, "EMPLOYEE", "JANE REA", new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 37335.03m, "PARCO", 0.0m, 0.0m, 65565.26m, 65565.26m, 32782.63m, 30.0m, 40700.9m, 491.74m, 491.74m, 2000.0m, 100.0m, 100.0m, 800.0m, 1600.0m, 7209.52m, 32431.97m, 30840.23m, 2000.0m, 1000.0m, 3608.92m, "BROADSPIRE-SEMI", new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEMI-MONTHLY", "BANK", 39743.29m, 61, 16391.32m, 0.0m, 189458.51m, 2291.74m, 300.0m, 2400.0m, 33921.4m, "PER MONTH", "S", "SEMI-MONTHLY", null, new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6494.8m },
                    { 3, 0.0m, null, "32170700", "SBC", 73882.82m, "11", 5035, "PESO", 3396.91m, new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3694.14m, 67016, 345.88m, 0.0m, 0.0m, 0.0m, 345.88m, 0.0m, 0.0m, null, 1.0m, "EMPLOYEE", "JOY", new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 37941.41m, "FRANCIA", 2404.03m, 0.0m, 73882.82m, 73882.82m, 36941.41m, 30.0m, 37941.41m, 554.12m, 554.12m, 2000.0m, 100.0m, 100.0m, 800.0m, 1600.0m, 6362.96m, 26801.93m, 31245.98m, 2000.0m, 1000.0m, 0.0m, "BROADSPIRE-SEMI", new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEMI-MONTHLY", "BANK", 40287.29m, 61, 18470.71m, 0.0m, 185541.82m, 2354.12m, 300.0m, 2400.0m, 32746.41m, "PER MONTH", "S", "SEMI-MONTHLY", null, new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6695.43m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpMaster_EmployeeId",
                table: "EmpMaster",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtRate_Key",
                table: "OtRate",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OTREG_PAYROLL #",
                table: "OTREG",
                column: "PAYROLL #");

            migrationBuilder.CreateIndex(
                name: "IX_PAYREG_PAYROLL #",
                table: "PAYREG",
                column: "PAYROLL #");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAttendance_PAYROLL #",
                table: "TimeAttendance",
                column: "PAYROLL #");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpMaster");

            migrationBuilder.DropTable(
                name: "OtRate");

            migrationBuilder.DropTable(
                name: "OTREG");

            migrationBuilder.DropTable(
                name: "PAYREG");

            migrationBuilder.DropTable(
                name: "TimeAttendance");
        }
    }
}
