using FinanceAPI.Extensions;
using Serilog;

var builder = WebApplication
    .CreateBuilder(args)
    .ConfigureApplicationBuilder();

var app = builder
    .Build()
    .ConfigureApplication();

try
{
    Log.Information("FinancePortalAPI Starting Up");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "FinancePortalAPI Terminated Unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}