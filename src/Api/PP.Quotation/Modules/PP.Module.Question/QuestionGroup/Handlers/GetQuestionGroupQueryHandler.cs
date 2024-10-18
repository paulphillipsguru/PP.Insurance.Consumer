using PP.Module.Question.Infrastructure;
using PP.Module.Question.Mapping;

namespace PP.Module.Question.QuestionGroup.Handlers
{
    public class GetQuestionGroupQueryHandler(IDBContext context) : IRequestHandler<GetQuestionGroupQuery, GetQuestionGroupResponse>
	{
		public async Task<GetQuestionGroupResponse> Handle(GetQuestionGroupQuery request, CancellationToken cancellationToken)
		{
			var questonGroups = await context.QuestionGroupDomain.ToListAsync(cancellationToken);

			return questonGroups.ToGetQuestionGroupResponseDto();
		}
	}
}
