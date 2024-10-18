using PP.Module.Question.Occupation.Domain;

namespace PP.Module.Question.Infrastructure
{
    public interface IDBContext
	{	
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
		public DbSet<QuestionGroupDomain> QuestionGroupDomain { get; set; }
		public DbSet<OccupationDomain> OccupationDomain { get; set; }
	}
}
