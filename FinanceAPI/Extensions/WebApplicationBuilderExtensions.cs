using FinanceAPI.Application.Extensions;
using FinanceAPI.Infrastructure.Extensions;

namespace FinanceAPI.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureApplicationBuilder(this WebApplicationBuilder builder)
    {
        #region OpenAPI

        builder.Services.AddOpenApi();

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
