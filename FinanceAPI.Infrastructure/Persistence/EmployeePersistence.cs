using FinanceAPI.Application.Employee;
using FinanceAPI.Application.Employee.DTOs;
using FinanceAPI.Domain.Models;
using FinanceAPI.Infrastructure.Database;
using FinanceAPI.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.Infrastructure.Persistence;
public sealed class EmployeePersistence : IEmployee
{
    private readonly DatabaseContext _context;

    public EmployeePersistence(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<EmployeeResponseDto> GetEmployeeById(int id, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .Where(x => x.Id == id)
            .Include(x => x.Department)
            .Include(x => x.PostTitle)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        var employeeDto = employee.MapToEmployeeResponseDto();

        return employeeDto;
    }

    public async Task<EmployeeResponseDto> CreateEmployee(EmployeeRequestDto employee, CancellationToken cancellationToken)
    {
        var newEmployee = new Employee
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            DateOfBirth = employee.DateOfBirth,
            Email = employee.Email,
            DateJoined = employee.DateJoined,
            DepartmentId = employee.DepartmentId,
            PostTitleId = employee.PostTitleId,
            IsActive = true,
            DateCreated = DateTime.Now,
            DateModified = DateTime.Now,
            Status = "I"
        };

        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync(cancellationToken);

        return await GetEmployeeById(newEmployee.Id, cancellationToken);
    }
}
