using PP.Module.Question.Occupation.Domain;

namespace PP.Module.Question.Infrastructure
{
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options), IDBContext
	{
		public DbSet<QuestionGroupDomain> QuestionGroupDomain { get; set; }
		public DbSet<OccupationDomain> OccupationDomain { get; set; }
	}
}
