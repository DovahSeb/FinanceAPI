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

        return builder;
    }
}
