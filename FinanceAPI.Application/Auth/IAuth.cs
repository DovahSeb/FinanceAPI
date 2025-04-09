using FinanceAPI.Application.Auth.DTOs;

namespace FinanceAPI.Application.Auth;
public interface IAuth
{
    Task<(bool IsSuccess, List<string> Errors)> ChangePassword(ChangePasswordRequestDto request, CancellationToken cancellationToken);
    Task Logout(CancellationToken cancellationToken);
}
