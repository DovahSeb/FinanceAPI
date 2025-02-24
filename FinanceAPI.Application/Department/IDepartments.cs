using FinanceAPI.Application.Department.DTOs;

namespace FinanceAPI.Application.Department;
public interface IDepartments
{
    Task<List<DepartmentResponseDto>> GetDepartments(CancellationToken cancellationToken);
}
