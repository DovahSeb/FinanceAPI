namespace FinanceAPI.Infrastructure.Email.Interface;
public interface IEmailService
{
    Task SendBirthdayEmail(CancellationToken cancellationToken);
}
