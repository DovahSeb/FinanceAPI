using FinanceAPI.Application.Employee.DTOs;
using MediatR;

namespace FinanceAPI.Application.Employee.Queries.GetEmployeeById;
public class GetEmployeeByIdHandler(IEmployee employee) : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponseDto>
{
    public async Task<EmployeeResponseDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var existingEmployee = await employee.GetEmployeeById(request.Id, cancellationToken);

        return existingEmployee;
    }
}
