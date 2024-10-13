using PP.Question.Service.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors();
builder.RegisterQuestion();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}
//DEV PURPOSE ONLY
app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();

app.RegisterOccupationEndPoints();

app.Run();
