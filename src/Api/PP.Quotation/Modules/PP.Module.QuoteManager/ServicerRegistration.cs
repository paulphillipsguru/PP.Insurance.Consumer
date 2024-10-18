using PP.Module.Common.Exceptions;
using PP.Module.QuoteManager.Dal;
using PP.Module.QuoteManager.Quotes.Commands;

namespace PP.Module.QuoteManager;

public static class ServicerRegistration
{
	private static string ConnectionString = "PP.Module.QuoteManager:ConnectionString";
	public static WebApplicationBuilder RegisterQuote(this WebApplicationBuilder builder)
	{
		builder.Services.AddTransient<IDataContract, DataContext>();
		builder.Services.AddMediatR(cfg => {
			cfg.RegisterServicesFromAssembly(typeof(IQuoteManagerModule).Assembly);
		});
		builder.Services.AddDbContext<DataContext>(options => {
			var connectinoString = builder.Configuration[ConnectionString];
			if (string.IsNullOrWhiteSpace(connectinoString))
			{
				throw new MissingSqlConnectionStringConfig(ConnectionString);
			}

			options.UseSqlServer(connectinoString);
		});



		return builder;
	}
	public static WebApplication RegisterQuoteManagerEndPoints(this WebApplication app)
	{

		app.MapGet("/Quote/Start/{seedKey}", async (IMediator mediator, string seedKey,CancellationToken token) =>
		{		
			try
			{
				var command = new StartQuoteCommand() { SeedCode  = seedKey };
				var result = await mediator.Send(command, token);

				return Results.Ok(result);
			}
			catch (Exception ex)
			{

				//TO DO: HANDLE EXCEPTION
				return Results.InternalServerError();
			}
		});

		return app;
	}

}
