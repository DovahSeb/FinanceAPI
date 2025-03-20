using Microsoft.AspNetCore.Identity;

namespace FinanceAPI.Endpoints;

public static class AuthEndpoints
{
    public static WebApplication MapAuthEndpoints(this WebApplication app)
    {
        app.MapGroup("/api/auth").WithTags("Auth").WithOpenApi().MapIdentityApi<IdentityUser>();

        return app;
    }
}
