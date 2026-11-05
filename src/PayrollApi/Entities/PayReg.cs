using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollApi.Entities;

[Table("PAYREG")]
public class PayReg
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("PAYROLL #")]
    public int? PayrollNo { get; set; }

    [Column("PAY DATE", TypeName = "date")]
    public DateTime? PayDate { get; set; }

    [Column("PAY CODE")]
    public string? PayCode { get; set; }

    [Column("EMPLOYEE ID#")]
    public int? EmployeeId { get; set; }

    [Column("LAST NAME")]
    public string? LastName { get; set; }

    [Column("FIRST NAME")]
    public string? FirstName { get; set; }

    [Column("FILE STATUS")]
    public string? FileStatus { get; set; }

    [Column("TAX STATUS")]
    public string? TaxStatus { get; set; }

    [Column("MONTHLY SALARY RATE", TypeName = "numeric(18,2)")]
    public decimal? MonthlySalaryRate { get; set; }

    [Column("BASIC SALARY", TypeName = "numeric(18,2)")]
    public decimal? BasicSalary { get; set; }

    [Column("DAILY RATE", TypeName = "numeric(18,2)")]
    public decimal? DailyRate { get; set; }

    [Column("SALARY RATE TYPE")]
    public string? SalaryRateType { get; set; }

    [Column("ATT DEDUCTION", TypeName = "numeric(18,2)")]
    public decimal? AttDeduction { get; set; }

    [Column("OVERTIME", TypeName = "numeric(18,2)")]
    public decimal? Overtime { get; set; }

    [Column("OTHER TX INCOME", TypeName = "numeric(18,2)")]
    public decimal? OtherTxIncome { get; set; }

    [Column("ADJUSTMENTS", TypeName = "numeric(18,2)")]
    public decimal? Adjustments { get; set; }

    [Column("GROSS INCOME", TypeName = "numeric(18,2)")]
    public decimal? GrossIncome { get; set; }

    [Column("EMPLOYEE SSS", TypeName = "numeric(18,2)")]
    public decimal? EmployeeSss { get; set; }

    [Column("EMPLOYEE MCR", TypeName = "numeric(18,2)")]
    public decimal? EmployeeMcr { get; set; }

    [Column("EMPLOYEE PAG-IBIG", TypeName = "numeric(18,2)")]
    public decimal? EmployeePagIbig { get; set; }

    [Column("TAXABLE INCOME", TypeName = "numeric(18,2)")]
    public decimal? TaxableIncome { get; set; }

    [Column("WITHOLDING TAX", TypeName = "numeric(18,2)")]
    public decimal? WitholdingTax { get; set; }

    [Column("NET SALARY AFTER TAX", TypeName = "numeric(18,2)")]
    public decimal? NetSalaryAfterTax { get; set; }

    [Column("OTHER NTX INCOME", TypeName = "numeric(18,2)")]
    public decimal? OtherNtxIncome { get; set; }

    [Column("LOAN PAYMENTS", TypeName = "numeric(18,2)")]
    public decimal? LoanPayments { get; set; }

    [Column("DEDUCTIONS", TypeName = "numeric(18,2)")]
    public decimal? Deductions { get; set; }

    [Column("NET SALARY", TypeName = "numeric(18,2)")]
    public decimal? NetSalary { get; set; }

    [Column("EMPLOYER SSS", TypeName = "numeric(18,2)")]
    public decimal? EmployerSss { get; set; }

    [Column("EMPLOYER MCR", TypeName = "numeric(18,2)")]
    public decimal? EmployerMcr { get; set; }

    [Column("EMPLOYER EC", TypeName = "numeric(18,2)")]
    public decimal? EmployerEc { get; set; }

    [Column("EMPLOYER PAG-IBIG", TypeName = "numeric(18,2)")]
    public decimal? EmployerPagIbig { get; set; }

    [Column("PAYROLL COST", TypeName = "numeric(18,2)")]
    public decimal? PayrollCost { get; set; }

    [Column("PREVIOUS YTD GROSS", TypeName = "numeric(18,2)")]
    public decimal? PreviousYtdGross { get; set; }

    [Column("PREVIOUS YTD WITHOLDING", TypeName = "numeric(18,2)")]
    public decimal? PreviousYtdWitholding { get; set; }

    [Column("PREVIOUS YTD SSS", TypeName = "numeric(18,2)")]
    public decimal? PreviousYtdSss { get; set; }

    [Column("PREVIOUS YTD MCR", TypeName = "numeric(18,2)")]
    public decimal? PreviousYtdMcr { get; set; }

    [Column("PREVIOUS YTD PAG-IBIG", TypeName = "numeric(18,2)")]
    public decimal? PreviousYtdPagIbig { get; set; }

    [Column("PREVIOUS YTD BON/13TH NT", TypeName = "numeric(18,2)")]
    public decimal? PreviousYtdBon13thNt { get; set; }

    [Column("PREVIOUS YTD BON/13TH TX", TypeName = "numeric(18,2)")]
    public decimal? PreviousYtdBon13thTx { get; set; }

    [Column("PAYMENT TYPE")]
    public string? PaymentType { get; set; }

    [Column("BANK ACCT#")]
    public string? BankAcctNo { get; set; }

    [Column("BANK NAME")]
    public string? BankName { get; set; }

    [Column("COMMENT FIELD")]
    public string? CommentField { get; set; }

    [Column("ERROR FIELD")]
    public string? ErrorField { get; set; }

    [Column("DATE EMPLOYED", TypeName = "date")]
    public DateTime? DateEmployed { get; set; }

    [Column("DATE TERMINATED", TypeName = "date")]
    public DateTime? DateTerminated { get; set; }

    [Column("COST CENTER")]
    public int? CostCenter { get; set; }

    [Column("CURRENCY")]
    public string? Currency { get; set; }

    [Column("EXCHANGE RATE", TypeName = "numeric(18,2)")]
    public decimal? ExchangeRate { get; set; }

    [Column("TAX TABLE")]
    public string? TaxTable { get; set; }

    [Column("PAYMENT FREQ")]
    public string? PaymentFreq { get; set; }

    [Column("MTD GROSS", TypeName = "numeric(18,2)")]
    public decimal? MtdGross { get; set; }

    [Column("MTD BASIC", TypeName = "numeric(18,2)")]
    public decimal? MtdBasic { get; set; }

    [Column("MTD SSS EMPLOYEE", TypeName = "numeric(18,2)")]
    public decimal? MtdSssEmployee { get; set; }

    [Column("MTD MCR EMPLOYEE", TypeName = "numeric(18,2)")]
    public decimal? MtdMcrEmployee { get; set; }

    [Column("MTD PAG-IBIG EMPLOYEE", TypeName = "numeric(18,2)")]
    public decimal? MtdPagIbigEmployee { get; set; }

    [Column("MTD SSS EMPLOYER", TypeName = "numeric(18,2)")]
    public decimal? MtdSssEmployer { get; set; }

    [Column("MTD MCR EMPLOYER", TypeName = "numeric(18,2)")]
    public decimal? MtdMcrEmployer { get; set; }

    [Column("MTD EC EMPLOYER", TypeName = "numeric(18,2)")]
    public decimal? MtdEcEmployer { get; set; }

    [Column("MTD PAG-IBIG EMPLOYER", TypeName = "numeric(18,2)")]
    public decimal? MtdPagIbigEmployer { get; set; }

    [Column("MTD WH TAX", TypeName = "numeric(18,2)")]
    public decimal? MtdWhTax { get; set; }

    [Column("MONTHLY SALARY RATE 2", TypeName = "numeric(18,2)")]
    public decimal? MonthlySalaryRate2 { get; set; }

    [Column("MONTHLY ALLOW", TypeName = "numeric(18,2)")]
    public decimal? MonthlyAllow { get; set; }

    [Column("MTD NTX", TypeName = "numeric(18,2)")]
    public decimal? MtdNtx { get; set; }

    [Column("FROM", TypeName = "date")]
    public DateTime? From { get; set; }

    [Column("TO", TypeName = "date")]
    public DateTime? To { get; set; }


}
