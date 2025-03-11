using FinanceAPI.Application.Employee.DTOs;
using MediatR;

namespace FinanceAPI.Application.Employee.Queries.GetEmployees;
public class GetEmployeesHandler(IEmployee employee) : IRequestHandler<GetEmployeesQuery, List<EmployeeResponseDto>>
{
    public async Task<List<EmployeeResponseDto>> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
    {
        return await employee.GetEmployees(cancellationToken);
    }
}
