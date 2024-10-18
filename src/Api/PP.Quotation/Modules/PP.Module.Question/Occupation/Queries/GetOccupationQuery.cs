namespace PP.Module.Question.Occupation.Queries
{
    public class GetOccupationQuery : IRequest<GetOccupationQueryResponse> {
        public required string Search {  get; set; }    
    }
}
