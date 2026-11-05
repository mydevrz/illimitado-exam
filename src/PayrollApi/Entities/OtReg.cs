using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollApi.Entities;

[Table("OTREG")]
public class OtReg
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

    [Column("OT CODE")]
    public string? OtCode { get; set; }

    [Column("DATE", TypeName = "date")]
    public DateTime? Date { get; set; }

    [Column("COST CENTER")]
    public int? CostCenter { get; set; }

    [Column("OT RATE", TypeName = "numeric(18,2)")]
    public decimal? OtRate { get; set; }

    [Column("OT HOURS", TypeName = "numeric(18,2)")]
    public decimal? OtHours { get; set; }

    [Column("OT MINUTES", TypeName = "numeric(18,2)")]
    public decimal? OtMinutes { get; set; }

    [Column("OT AMOUNT", TypeName = "numeric(18,2)")]
    public decimal? OtAmount { get; set; }

    [Column("OT NP HOURS", TypeName = "numeric(18,2)")]
    public decimal? OtNpHours { get; set; }

    [Column("OT NP MINUTES", TypeName = "numeric(18,2)")]
    public decimal? OtNpMinutes { get; set; }

    [Column("OT NP AMOUNT", TypeName = "numeric(18,2)")]
    public decimal? OtNpAmount { get; set; }

    [Column("OT NP2 HOURS", TypeName = "numeric(18,2)")]
    public decimal? OtNp2Hours { get; set; }

    [Column("OT NP2 MINUTES", TypeName = "numeric(18,2)")]
    public decimal? OtNp2Minutes { get; set; }

    [Column("OT NP2 AMOUNT", TypeName = "numeric(18,2)")]
    public decimal? OtNp2Amount { get; set; }

    [Column("OT AND NP AMOUNT", TypeName = "numeric(18,2)")]
    public decimal? OtAndNpAmount { get; set; }

    [Column("RECUR START", TypeName = "date")]
    public DateTime? RecurStart { get; set; }

    [Column("RECUR END", TypeName = "date")]
    public DateTime? RecurEnd { get; set; }

    [Column("FREQ")]
    public string? Freq { get; set; }

    [Column("REMARKS")]
    public string? Remarks { get; set; }

    [Column("SYSTEM OT HOURS", TypeName = "numeric(18,2)")]
    public decimal? SystemOtHours { get; set; }

    [Column("SYSTEM OT TIME")]
    public string? SystemOtTime { get; set; }

    [Column("SYSTEM NP HOURS", TypeName = "numeric(18,2)")]
    public decimal? SystemNpHours { get; set; }

    [Column("SYSTEM NP TIME")]
    public string? SystemNpTime { get; set; }

    [Column("FROM", TypeName = "date")]
    public DateTime? From { get; set; }

    [Column("TO", TypeName = "date")]
    public DateTime? To { get; set; }

    [Column("JE COST CENTER")]
    public int? JeCostCenter { get; set; }


}
