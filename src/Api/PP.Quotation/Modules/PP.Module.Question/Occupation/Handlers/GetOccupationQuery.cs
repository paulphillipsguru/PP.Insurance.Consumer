using PP.Module.Question.Infrastructure;
using PP.Module.Question.Occupation.Queries;

namespace PP.Module.Question.Occupation.Handlers;
public class AddOccupationHandler(IDBContext context) : IRequestHandler<GetOccupationQuery, GetOccupationQueryResponse>
{
	public async Task<GetOccupationQueryResponse> Handle(GetOccupationQuery request, CancellationToken cancellationToken)
	{
		var occupationList = await context.OccupationDomain.Where(p => p.Name.Contains(request.Search)).Take(25).ToListAsync(cancellationToken);
		return occupationList.ToGetOccupationQueryResponseDto();		
	}
}