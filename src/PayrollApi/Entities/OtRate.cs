using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollApi.Entities;

/// <summary>Premium rate per TimeAttendance column (Calculator sheet, row 8).</summary>
[Table("OtRate")]
public class OtRate
{
    [Key]
    public int Id { get; set; }

    /// <summary>Property name on <see cref="TimeAttendance"/> that holds the hours/days.</summary>
    public string Key { get; set; } = "";
    public string Description { get; set; } = "";

    /// <summary>"Hours" (hourly rate) or "Days" (daily rate, no 8 divisor).</summary>
    public string Unit { get; set; } = "Hours";

    /// <summary>"Deduction" (ATT DEDUCTION), "Overtime" (OVERTIME) or "Excluded".</summary>
    public string Category { get; set; } = "Overtime";

    [Column(TypeName = "numeric(10,4)")]
    public decimal PremiumRate { get; set; }

    public string? Note { get; set; }
}
