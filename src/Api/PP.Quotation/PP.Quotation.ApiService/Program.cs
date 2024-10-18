using PP.Module.Question;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddCors();

builder.RegisterQuestion();


var app = builder.Build();
app.UseCors(p=>p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseExceptionHandler();

app.MapDefaultEndpoints();
app.RegisterOccupationEndPoints();
app.Run();

