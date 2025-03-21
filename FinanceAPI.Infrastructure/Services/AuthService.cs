using FinanceAPI.Application.Auth;
using Microsoft.AspNetCore.Identity;

namespace FinanceAPI.Infrastructure.Services;
public sealed class AuthService : IAuth
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthService(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task Logout(CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync().ConfigureAwait(false);
    }
}
