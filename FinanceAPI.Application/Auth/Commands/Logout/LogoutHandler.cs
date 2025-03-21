using MediatR;

namespace FinanceAPI.Application.Auth.Commands.Logout;
public class LogoutHandler(IAuth auth) : IRequestHandler<LogoutCommand>
{
    public async Task Handle(LogoutCommand command, CancellationToken cancellationToken)
    {
        await auth.Logout(cancellationToken);
    }
}
