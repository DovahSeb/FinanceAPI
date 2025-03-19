using FinanceAPI.Application.Department;
using FinanceAPI.Application.Department.DTOs;
using FinanceAPI.Infrastructure.Database;
using FinanceAPI.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.Infrastructure.Services;
public sealed class DepartmentsService : IDepartment
{
    private readonly DatabaseContext _context;

    public DepartmentsService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<DepartmentResponseDto>> GetDepartments(CancellationToken cancellationToken)
    {
        var departments = await _context.Departments
            .Where(x => !x.Status.Equals("D"))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var departmentDto = departments
            .Select(x => x.MapToDepartmentResponseDto())
            .ToList();

        if (!departmentDto.Any())
        {
            return [];
        }

        return departmentDto;
    }
}
