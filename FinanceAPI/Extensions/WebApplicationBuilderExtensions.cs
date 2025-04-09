using FinanceAPI.Application.Extensions;
using FinanceAPI.Exceptions;
using FinanceAPI.Infrastructure.Database;
using FinanceAPI.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Serilog;
using System.Reflection;

namespace FinanceAPI.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureApplicationBuilder(this WebApplicationBuilder builder)
    {
        #region Logger

        builder.Host.UseSerilog((hostContext, LoggerConfiguration) =>
        {
            var assembly = Assembly.GetEntryAssembly();

            LoggerConfiguration.ReadFrom.Configuration(hostContext.Configuration)
            .Enrich.WithProperty(
                "AssemblyVersion",
                assembly?.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version
            )
            .Enrich.WithProperty(
                "Assembly Informational Version",
                assembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
            );
        });

        #endregion

        #region OpenAPI

        builder.Services.AddOpenApi();

        #endregion

        #region Authorization Policy

        builder.Services.AddAuthorization();

        #endregion

        #region .Net Identity Provider

        builder.Services.AddIdentityApiEndpoints<IdentityUser>(opt =>
        {
            opt.User.RequireUniqueEmail = true;
            opt.Password.RequiredLength = 8;
        })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DatabaseContext>();

        builder.Services.AddHttpContextAccessor();

        #endregion

        #region Exception Handling

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        #endregion

        #region Project Dependencies

        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddApplication();

        #endregion

        #region Cors

        builder.Services.AddCors(options =>
        {
            var allowedOrigin = builder.Configuration.GetValue<string>("CORSPolicy:AllowedOrigin");

            options.AddDefaultPolicy(x => {
                x.WithOrigins(allowedOrigin);
                x.AllowAnyMethod();
                x.AllowAnyHeader();
                x.AllowCredentials();
            });
        });

        #endregion Cors

        return builder;
    }
}
