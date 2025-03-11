using FinanceAPI.Application.Employee.DTOs;

namespace FinanceAPI.Application.Employee;
public interface IEmployee
{
    Task<List<EmployeeResponseDto>> GetEmployees(CancellationToken cancellationToken);
    Task<EmployeeResponseDto> GetEmployeeById(int id, CancellationToken cancellationToken);
    Task<EmployeeResponseDto> CreateEmployee(EmployeeRequestDto employee, CancellationToken cancellationToken);
}
