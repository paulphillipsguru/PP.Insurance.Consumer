using PP.Module.Question.Occupation.Domain;
using PP.Module.Question.Occupation.Queries;

namespace PP.Module.Question.Mapping
{
    public static class Map
    {
        private readonly static Mapper _map;
        static Map()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuestionGroupDomain, QuestionGroupRecord>();
                cfg.CreateMap<OccupationDomain, OccupationRecord>();
            }
            );

            _map = new Mapper(config);
        }

        public static GetQuestionGroupResponse ToGetQuestionGroupResponseDto(this List<QuestionGroupDomain> questionGroupDomain)
        {
            return new GetQuestionGroupResponse() { QuestionGroupRecords = _map.Map<List<QuestionGroupRecord>>(questionGroupDomain) };
        }

        public static GetOccupationQueryResponse ToGetOccupationQueryResponseDto(this List<OccupationDomain> occupationDomain)
        {
            return new GetOccupationQueryResponse() { OccupationRecords = _map.Map<List<OccupationRecord>>(occupationDomain) };
        }
    }
}
