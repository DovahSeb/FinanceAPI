using FinanceAPI.Application.Auth.DTOs;
using MediatR;

namespace FinanceAPI.Application.Auth.Commands.ChangePassword;
public sealed class ChangePasswordHandler(IAuth auth) : IRequestHandler<ChangePasswordCommand, (bool IsSuccess, List<string> Errors)>
{
    public async Task<(bool IsSuccess, List<string> Errors)> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
    {
        var passwordChange = new ChangePasswordRequestDto(command.CurrentPassword, command.NewPassword, command.ConfirmPassword);
        return await auth.ChangePassword(passwordChange, cancellationToken);
    }
}
