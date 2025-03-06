using FinanceAPI.Application.Department.DTOs;

namespace FinanceAPI.Application.Department;
public interface IDepartment
{
    Task<List<DepartmentResponseDto>> GetDepartments(CancellationToken cancellationToken);
}
