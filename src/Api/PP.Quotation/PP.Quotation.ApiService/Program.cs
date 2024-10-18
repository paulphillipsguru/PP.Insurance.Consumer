using PP.Module.Question;
using PP.Module.QuoteManager;


//Dictionary<string, int> sequenceCounters = [];
//Dictionary<string, int> sequenceThresholds = [];



//var seed = new PolicyNumberGenerator("[QUOTE]/[@YYYY@MM@DD]#SEQ1#SEQ2#SEQ3/[PI]", sequenceThresholds, sequenceCounters);

//sequenceCounters.Add("#SEQ1", 0);
//sequenceCounters.Add("#SEQ2", 0);
//sequenceCounters.Add("#SEQ3", 0);

//sequenceThresholds.Add("#SEQ1", 3000000);
//sequenceThresholds.Add("#SEQ2", 300000);
//sequenceThresholds.Add("#SEQ3", 30000);




//var quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();
//quoteNumbner = seed.GeneratePolicyNumber();


var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddCors();

builder.RegisterQuestion();
builder.RegisterQuote();

var app = builder.Build();
app.UseCors(p=>p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseExceptionHandler();

app.MapDefaultEndpoints();
app.RegisterOccupationEndPoints();
app.RegisterQuoteManagerEndPoints();
app.Run();

