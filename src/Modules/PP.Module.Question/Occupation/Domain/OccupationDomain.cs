using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PP.Module.Question.Occupation.Domain;

[Table("Occupation")]
public class OccupationDomain
{
    [Key]
    public required string Code { get; set; }
    public required string Name { get; set; }
}
