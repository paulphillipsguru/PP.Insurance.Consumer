using PP.Module.Question.Infrastructure;
using PP.Module.Question.Occupation.Queries;
using Newtonsoft.Json.Linq;

namespace PP.Module.Question;

public static class ServicerRegistration
{
	public static WebApplicationBuilder RegisterQuestion(this WebApplicationBuilder builder)
	{
		builder.Services.AddTransient<IDBContext, DBContext>();
		builder.Services.AddMediatR(cfg => {
			cfg.RegisterServicesFromAssembly(typeof(IQuestionModule).Assembly);
		});
		builder.Services.AddDbContext<DBContext>(options => {
			options.UseSqlServer(builder.Configuration["PP.Module.Question:ConnectionString"]);
		});



		return builder;
	}
	public static WebApplication RegisterOccupationEndPoints(this WebApplication app)
	{

		app.MapGet("/Occupation", async (IMediator mediator, HttpContext context) =>
		{
			if (!context.Request.Query.ContainsKey("Filter"))
			{
				return Results.BadRequest("Missing Filter");
			}

			var filter = context.Request.Query["Filter"].ToString();

			if (string.IsNullOrEmpty(filter))
			{
				return Results.BadRequest("Missing Filter");
			}

			var query = JArray.Parse(filter);
			var searchString = string.Empty;
			if (query == null)
			{
				return Results.BadRequest("Missing Filter");
			}


			try
			{
				searchString = query[0][2].ToString();

				var result = await mediator.Send<GetOccupationQueryResponse>(new GetOccupationQuery() { Search = searchString });

				return Results.Ok(result);
			}
			catch (Exception ex)
			{

				//TODO HANDLE EXCEPTION
				return Results.InternalServerError();
			}
		});

		return app;
	}

}
