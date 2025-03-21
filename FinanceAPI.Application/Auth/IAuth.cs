namespace FinanceAPI.Application.Auth;
public interface IAuth
{
    Task Logout(CancellationToken cancellationToken);
}
