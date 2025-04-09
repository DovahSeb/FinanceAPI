using FinanceAPI.Application.Auth;
using FinanceAPI.Application.Auth.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FinanceAPI.Infrastructure.Services;
public sealed class AuthService : IAuth
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthService(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<(bool IsSuccess, List<string> Errors)> ChangePassword(ChangePasswordRequestDto request, CancellationToken cancellationToken)
    {
        if (request.NewPassword != request.ConfirmPassword)
        {
            return (false, new List<string> { "New password and confirmation do not match." });
        }

        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        if (user is null)
        {
            return (false, new List<string> { "User not found or not authenticated." });
        }

        var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!result.Succeeded)
        {
            return (false, result.Errors.Select(e => e.Description).ToList());
        }

        return (true, new List<string>());
    }

    public async Task Logout(CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync().ConfigureAwait(false);
    }
}
