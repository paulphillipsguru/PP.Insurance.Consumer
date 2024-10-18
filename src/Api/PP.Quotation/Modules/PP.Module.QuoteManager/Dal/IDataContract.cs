using PP.Module.QuoteManager.Contract.Entities;

namespace PP.Module.QuoteManager.Dal
{
	public interface IDataContract
	{
		DbSet<Seed> Seeds { get; set; }
		DbSet<Quote> Quote { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
		
	}
}
