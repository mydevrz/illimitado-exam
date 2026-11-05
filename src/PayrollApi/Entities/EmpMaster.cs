using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollApi.Entities;

[Table("EmpMaster")]
public class EmpMaster
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public string LastName { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string? FileStatus { get; set; }
    public string? TaxStatus { get; set; }

    // The source sheet labels this column "DAILY RATE" but it holds the monthly salary
    // (Calculator!D = EmpMaster!F). It is stored under the correct name.
    [Column(TypeName = "numeric(18,2)")]
    public decimal MonthlySalary { get; set; }
}
