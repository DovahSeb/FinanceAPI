using FinanceAPI.Application.Department;
using FinanceAPI.Application.Department.DTOs;
using FinanceAPI.Infrastructure.Database;
using FinanceAPI.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.Infrastructure.Persistence;
public sealed class Departments : IDepartment
{
    private readonly DatabaseContext _context;

    public Departments(DatabaseContext context)
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
