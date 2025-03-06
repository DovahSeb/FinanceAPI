using FinanceAPI.Application.Department.DTOs;
using MediatR;

namespace FinanceAPI.Application.Department.Queries;
public class GetDepartmentsHandler(IDepartment departments) : IRequestHandler<GetDepartmentsQuery, List<DepartmentResponseDto>>
{
    public async Task<List<DepartmentResponseDto>> Handle(GetDepartmentsQuery query, CancellationToken cancellationToken)
    {
        return await departments.GetDepartments(cancellationToken);
    }
}
