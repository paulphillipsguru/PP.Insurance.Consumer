using PP.Module.QuoteManager.Contract.Entities;
using PP.Module.QuoteManager.Core;
using PP.Module.QuoteManager.Dal;
using PP.Module.QuoteManager.Quotes.Commands;


namespace PP.Module.QuoteManager.Quotes.Handlers
{

	public class StartQuoteHandler(DataContext dbContext) : IRequestHandler<StartQuoteCommand, StartQuoteCommandResponse>
	{
		private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
		public async Task<StartQuoteCommandResponse> Handle(StartQuoteCommand request, CancellationToken cancellationToken)
		{
			//NOTE: We have to lock this process as we don't want duplicate quote references!
			await _semaphore.WaitAsync(); // Acquire the lock
			using var transaction = dbContext.Database.BeginTransaction();
			try
			{				
				Dictionary<string, int> sequenceCounters = [];
				Dictionary<string, int> sequenceThresholds = [];

				var seed = await dbContext.Seeds.Include(p => p.SeedSegmentSeeds).FirstAsync(p => p.SeedKey == request.SeedCode, cancellationToken);

				foreach (var seq in seed.SeedSegmentSeeds)
				{
					sequenceCounters[seq.SeekCode] = seq.SeedValue;
					sequenceThresholds[seq.SeekCode] = seq.Threshold;
				}
				var quoteNumberGen = new PolicyNumberGenerator(seed.Format, sequenceThresholds, ref sequenceCounters);
				var qouteNumber = quoteNumberGen.GeneratePolicyNumber();
				//Update the seed values for each segments
				foreach (var seq in seed.SeedSegmentSeeds)
				{
					seq.SeedValue = sequenceCounters[seq.SeekCode];

				}

				var quote =new Quote() {  DateCreated = DateTime.UtcNow, QuoteRef= qouteNumber };
				
				await dbContext.Quote.AddAsync(quote, cancellationToken);

				await dbContext.SaveChangesAsync(cancellationToken);
				

				await transaction.CommitAsync(cancellationToken);

				return new StartQuoteCommandResponse() { QuoteRef = qouteNumber };

			}
			catch(Exception ex)
			{
				await transaction.RollbackAsync(cancellationToken);
				//TODO: HANDLE ERROR
				throw;
			}
			finally
			{
				_semaphore.Release(); // Release the lock
			}			
		}
	}
}
