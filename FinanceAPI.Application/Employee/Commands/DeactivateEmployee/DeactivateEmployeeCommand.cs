using MediatR;

namespace FinanceAPI.Application.Employee.Commands.DeactivateEmployee;
public sealed record DeactivateEmployeeCommand(int Id) : IRequest;
