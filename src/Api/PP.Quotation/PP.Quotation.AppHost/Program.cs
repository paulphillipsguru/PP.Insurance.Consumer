var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.PP_Quotation_ApiService>("Quotation-Service")
	.WithReference(cache)
	.WaitFor(cache);


builder.Build().Run();
