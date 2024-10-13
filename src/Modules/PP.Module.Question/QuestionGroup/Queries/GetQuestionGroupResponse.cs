namespace PP.Module.Question.QuestionGroup.Queries
{
	public record GetQuestionGroupResponse
	{
		public required List<QuestionGroupRecord> QuestionGroupRecords { get; set; }
	}

	public record QuestionGroupRecord
	{
		public String QuestionGroupCode { get; set; } = string.Empty;
		public String QuestionGroupName { get; set; } = string.Empty;
	}
}
