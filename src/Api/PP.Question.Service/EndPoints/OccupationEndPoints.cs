using MediatR;

namespace PP.Question.Service.EndPoints
{
	public static class OccupationEndPoints
	{
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

					//TO DO: HANDLE EXCEPTION
					return Results.InternalServerError();
				}
			});

			return app;
		}
	}
}
