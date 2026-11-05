using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollApi.Entities;

[Table("TimeAttendance")]
public class TimeAttendance
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("PAYROLL #")]
    public int? PayrollNo { get; set; }

    [Column("EMP ID#")]
    public int? EmployeeId { get; set; }

    [Column("LAST NAME")]
    public string? LastName { get; set; }

    [Column("FIRST NAME")]
    public string? FirstName { get; set; }

    [Column("REG DAYS WRK", TypeName = "numeric(18,2)")]
    public decimal? RegDaysWrk { get; set; }

    [Column("TARDY HRS", TypeName = "numeric(18,2)")]
    public decimal? TardyHrs { get; set; }

    [Column("UNDERTIME HRS", TypeName = "numeric(18,2)")]
    public decimal? UndertimeHrs { get; set; }

    [Column("ABSENT DAYS", TypeName = "numeric(18,2)")]
    public decimal? AbsentDays { get; set; }

    [Column("LWOP DAYS", TypeName = "numeric(18,2)")]
    public decimal? LwopDays { get; set; }

    [Column("VL DAYS", TypeName = "numeric(18,2)")]
    public decimal? VlDays { get; set; }

    [Column("SL DAYS", TypeName = "numeric(18,2)")]
    public decimal? SlDays { get; set; }

    [Column("OTHER LV DAYS", TypeName = "numeric(18,2)")]
    public decimal? OtherLvDays { get; set; }

    [Column("NITE-DIFF 10%", TypeName = "numeric(18,2)")]
    public decimal? NiteDiff10Pct { get; set; }

    [Column("REGULAR-OT", TypeName = "numeric(18,2)")]
    public decimal? RegularOt { get; set; }

    [Column("REG-OT (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? RegOtNpHrs10Pct { get; set; }

    [Column("LEGAL HOL OT", TypeName = "numeric(18,2)")]
    public decimal? LegalHolOt { get; set; }

    [Column("LEGAL HOL OT (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? LegalHolOtNpHrs10Pct { get; set; }

    [Column("LEGAL HOL OT > 8HRS", TypeName = "numeric(18,2)")]
    public decimal? LegalHolOtGt8hrs { get; set; }

    [Column("LEGAL HOL OT >8 (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? LegalHolOtGt8NpHrs10Pct { get; set; }

    [Column("LEGAL HOL RD", TypeName = "numeric(18,2)")]
    public decimal? LegalHolRd { get; set; }

    [Column("LEGAL HOL RD (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? LegalHolRdNpHrs10Pct { get; set; }

    [Column("LEGAL HOL RD >8HRS", TypeName = "numeric(18,2)")]
    public decimal? LegalHolRdGt8hrs { get; set; }

    [Column("LEGAL HOL RD >8 (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? LegalHolRdGt8NpHrs10Pct { get; set; }

    [Column("SPECL HOL OT", TypeName = "numeric(18,2)")]
    public decimal? SpeclHolOt { get; set; }

    [Column("SPECL HOL OT (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? SpeclHolOtNpHrs10Pct { get; set; }

    [Column("SPECL HOLIDAY OT >8", TypeName = "numeric(18,2)")]
    public decimal? SpeclHolidayOtGt8 { get; set; }

    [Column("SPECL HOL OT >8 (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? SpeclHolOtGt8NpHrs10Pct { get; set; }

    [Column("SPECIAL HOLIDAY RD", TypeName = "numeric(18,2)")]
    public decimal? SpecialHolidayRd { get; set; }

    [Column("SPECIAL HOL RD (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? SpecialHolRdNpHrs10Pct { get; set; }

    [Column("SPECL HOLIDAY ON RD > 8HRS", TypeName = "numeric(18,2)")]
    public decimal? SpeclHolidayOnRdGt8hrs { get; set; }

    [Column("SPECL HOL RD > 8 (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? SpeclHolRdGt8NpHrs10Pct { get; set; }

    [Column("REST DAY OT", TypeName = "numeric(18,2)")]
    public decimal? RestDayOt { get; set; }

    [Column("REST DAY OT (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? RestDayOtNpHrs10Pct { get; set; }

    [Column("REST DAY OT > 8HRS", TypeName = "numeric(18,2)")]
    public decimal? RestDayOtGt8hrs { get; set; }

    [Column("REST DAY OT > 8 (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? RestDayOtGt8NpHrs10Pct { get; set; }

    [Column("DOUBLE HOLIDAY OT", TypeName = "numeric(18,2)")]
    public decimal? DoubleHolidayOt { get; set; }

    [Column("DOUBLE HOLIDAY OT (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? DoubleHolidayOtNpHrs10Pct { get; set; }

    [Column("DOUBLE HOLIDAY OT > 8HRS", TypeName = "numeric(18,2)")]
    public decimal? DoubleHolidayOtGt8hrs { get; set; }

    [Column("DOUBLE HOLIDAY OT > 8 (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? DoubleHolidayOtGt8NpHrs10Pct { get; set; }

    [Column("DOUBLE HOLIDAY RD", TypeName = "numeric(18,2)")]
    public decimal? DoubleHolidayRd { get; set; }

    [Column("DOUBLE HOL RD (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? DoubleHolRdNpHrs10Pct { get; set; }

    [Column("DOUBLE HOL ON RD > 8HRS", TypeName = "numeric(18,2)")]
    public decimal? DoubleHolOnRdGt8hrs { get; set; }

    [Column("DOUBLE HOL RD > 8 (NP HRS 10%)", TypeName = "numeric(18,2)")]
    public decimal? DoubleHolRdGt8NpHrs10Pct { get; set; }

    [Column("Remarks")]
    public string? Remarks { get; set; }


}
