using FinanceAPI.Application.Employee.DTOs;

namespace FinanceAPI.Application.Employee;
public interface IEmployee
{
    Task<EmployeeResponseDto> GetEmployeeById(int id, CancellationToken cancellationToken);
    Task<EmployeeResponseDto> CreateEmployee(EmployeeRequestDto employee, CancellationToken cancellationToken);
}
