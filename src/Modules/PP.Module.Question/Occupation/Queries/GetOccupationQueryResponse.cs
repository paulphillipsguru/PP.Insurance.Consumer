namespace PP.Module.Question.Occupation.Queries
{
	public record GetOccupationQueryResponse
	{
		public List<OccupationRecord>? OccupationRecords { get; set; }
	}

	public record OccupationRecord
	{
		public required string Code { get; set; }
		public required string Name { get; set; }
	}
}
