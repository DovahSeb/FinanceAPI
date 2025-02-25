using FinanceAPI.Application.Department.DTOs;
using FinanceAPI.Domain.Models;

namespace FinanceAPI.Infrastructure.Mapping;
public static class DepartmentMappingExtensions
{
    public static DepartmentResponseDto MapToDepartmentResponseDto(this Department department)
    {
        return new DepartmentResponseDto(department.Id, department.Name);
    }
}
