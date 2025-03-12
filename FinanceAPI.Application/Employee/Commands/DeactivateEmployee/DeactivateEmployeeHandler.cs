using MediatR;

namespace FinanceAPI.Application.Employee.Commands.DeactivateEmployee;
public sealed class DeactivateEmployeeHandler(IEmployee employee) : IRequestHandler<DeactivateEmployeeCommand>
{
    public async Task Handle(DeactivateEmployeeCommand command, CancellationToken cancellationToken)
    {
        await employee.DeactivateEmployee(command.Id, cancellationToken);
    }
}
