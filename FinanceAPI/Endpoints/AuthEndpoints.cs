using FinanceAPI.Application.Auth.Commands.Logout;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinanceAPI.Endpoints;

public static class AuthEndpoints
{
    public static WebApplication MapAuthEndpoints(this WebApplication app)
    {
        app.MapGroup("/api/auth").WithTags("Auth").WithOpenApi().MapIdentityApi<IdentityUser>();

        var root = app.MapGroup("/api/auth").WithTags("Auth").WithOpenApi();

        root.MapPost("/logout/", Logout)
            .WithName("Logout User");

        return app;
    }

    public static async Task Logout(IMediator mediator, LogoutCommand command)
    {
        await mediator.Send(command);
    }
}
