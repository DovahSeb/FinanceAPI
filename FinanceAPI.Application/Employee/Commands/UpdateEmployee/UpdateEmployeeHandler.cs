using FinanceAPI.Application.Employee.DTOs;
using MediatR;

namespace FinanceAPI.Application.Employee.Commands.UpdateEmployee;
public sealed class UpdateEmployeeHandler(IEmployee employee) : IRequestHandler<UpdateEmployeeCommand, EmployeeResponseDto>
{
    public async Task<EmployeeResponseDto> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var updateEmployee = new EmployeeRequestDto(command.FirstName, command.OtherName, command.LastName, command.DateOfBirth, command.Email, command.DateJoined, command.DepartmentId, command.PostTitleId);
        return await employee.UpdateEmployee(command.Id, updateEmployee, cancellationToken);
    }
}
