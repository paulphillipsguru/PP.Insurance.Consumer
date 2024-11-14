using PP.Module.Question;
using PP.Module.QuoteManager;


var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddCors();


// MODULES REGISTRATION
builder.RegisterQuestion();
builder.RegisterQuote();

var app = builder.Build();

//TODO: CHANGE FOR PROD!
app.UseCors(p=>p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseExceptionHandler();

app.MapDefaultEndpoints();

// MODULES END POINTS
app.RegisterOccupationEndPoints();
app.RegisterQuoteManagerEndPoints();

app.Run();

