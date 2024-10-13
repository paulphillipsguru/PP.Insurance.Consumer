using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PP.Module.Question.Infrastructure;

namespace PP.Module.Question;

public interface IQuestionModule;

public static class RegisterQuestionModule
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


}