using FinanceAPI.Application.Auth.DTOs;
using MediatR;

namespace FinanceAPI.Application.Auth.Commands.ChangePassword;
public sealed record ChangePasswordCommand(string CurrentPassword, string NewPassword, string ConfirmPassword) : IRequest<(bool IsSuccess, List<string> Errors)>;
