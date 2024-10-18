using PP.Module.QuoteManager.Contract.Entities;

namespace PP.Module.QuoteManager.Dal
{
	public partial class DataContext : DbContext, IDataContract
	{
		public DbSet<Seed> Seeds { get; set; }
		public DbSet<Quote> Quote { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
#endif
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
