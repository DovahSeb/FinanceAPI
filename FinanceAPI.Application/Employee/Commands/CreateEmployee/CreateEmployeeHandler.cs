using FinanceAPI.Application.Employee.DTOs;
using MediatR;

namespace FinanceAPI.Application.Employee.Commands.CreateEmployee;
public sealed class CreateEmployeeHandler(IEmployee employee) : IRequestHandler<CreateEmployeeCommand, EmployeeResponseDto>
{
    public async Task<EmployeeResponseDto> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var newEmployee = new EmployeeRequestDto(command.FirstName, command.OtherName, command.LastName, command.DateOfBirth, command.Email, command.DateJoined, command.DepartmentId, command.PostTitleId);
        return await employee.CreateEmployee(newEmployee, cancellationToken);
    }
}
