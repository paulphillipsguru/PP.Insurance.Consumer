using System.ComponentModel.DataAnnotations;
namespace PP.Module.Question.QuestionGroup.Domain;

public class QuestionGroupDomain
{
    [Key]
    public required string QuestionGroupCode { get; set; }
    public required string QuestionGroupName { get; set; }
}
