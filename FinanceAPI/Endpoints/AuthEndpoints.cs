using FinanceAPI.Application.Auth.Commands.ChangePassword;
using FinanceAPI.Application.Auth.Commands.Logout;
using FinanceAPI.Infrastructure.Email.Interface;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinanceAPI.Endpoints;

public static class AuthEndpoints
{
    public static WebApplication MapAuthEndpoints(this WebApplication app)
    {
        app.MapGroup("/api/auth").WithTags("Auth").WithOpenApi().MapIdentityApi<IdentityUser>();

        var root = app.MapGroup("/api/auth").WithTags("Auth").WithOpenApi();

        root.MapPost("/change-password", ChangePassword)
            .WithName("Change User Password")
            .RequireAuthorization();

        root.MapPost("/logout", Logout)
            .WithName("Logout User");

        root.MapGet("/birthdayEmail", async (IEmailService emailService, CancellationToken cancellationToken) =>
        {
            await emailService.SendBirthdayEmail(cancellationToken);
            return Results.Ok();
        });

        return app;
    }

    public static async Task<IResult> ChangePassword(IMediator mediator, ChangePasswordCommand command)
    {
        var (isSuccess, errors) = await mediator.Send(command);

        if (!isSuccess)
            return Results.BadRequest(errors);

        return Results.Ok("Password changed successfully.");
    }

    public static async Task Logout(IMediator mediator, LogoutCommand command)
    {
        await mediator.Send(command);
    }
}
