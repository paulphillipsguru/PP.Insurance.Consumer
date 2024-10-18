namespace PP.Module.Question.QuestionGroup.Queries
{
	public class GetQuestionGroupQuery : IRequest<GetQuestionGroupResponse>
	{
		public required string Category { get; set; }
	}
}
