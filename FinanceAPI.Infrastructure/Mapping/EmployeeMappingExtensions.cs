using FinanceAPI.Application.Employee.DTOs;
using FinanceAPI.Domain.Models;

namespace FinanceAPI.Infrastructure.Mapping;
public static class EmployeeMappingExtensions
{
    public static EmployeeResponseDto MapToEmployeeResponseDto(this Employee employee)
    {
        return new EmployeeResponseDto(employee.Id, employee.FirstName, employee.OtherName, employee.LastName, employee.DateOfBirth, employee.Email, employee.DateJoined, employee.Department.Name, employee.PostTitle.Name, employee.IsActive);
    }
}
