﻿using FinanceAPI.Application.Common.Enums;
using FinanceAPI.Application.Common.Exceptions;
using FinanceAPI.Application.Employee;
using FinanceAPI.Application.Employee.DTOs;
using FinanceAPI.Domain.Models;
using FinanceAPI.Infrastructure.Database;
using FinanceAPI.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.Infrastructure.Services;
public sealed class EmployeeService : IEmployee
{
    private readonly DatabaseContext _context;

    public EmployeeService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<EmployeeResponseDto>> GetEmployees(CancellationToken cancellationToken)
    {
        var employees = await _context.Employees
            .Where(x => x.Status != EntryStatus.Deleted)
            .Include(x => x.Department)
            .Include(x => x.PostTitle)
            .OrderBy(x => x.LastName)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var employeesDto = employees
            .Select(x => x.MapToEmployeeResponseDto())
            .ToList();

        if (!employeesDto.Any())
        {
            return [];
        }

        return employeesDto;
    }

    public async Task<EmployeeResponseDto> GetEmployeeById(int id, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .Where(x => x.Id == id)
            .Include(x => x.Department)
            .Include(x => x.PostTitle)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        NotFoundException.ThrowIfNull(employee, EntityType.Employee);

        var employeeDto = employee.MapToEmployeeResponseDto();

        return employeeDto;
    }

    public async Task<EmployeeResponseDto> CreateEmployee(EmployeeRequestDto employee, CancellationToken cancellationToken)
    {
        var newEmployee = new Employee
        {
            FirstName = employee.FirstName,
            OtherName = employee.OtherName,
            LastName = employee.LastName.ToUpper(),
            DateOfBirth = employee.DateOfBirth,
            Email = employee.Email,
            DateJoined = employee.DateJoined,
            DepartmentId = employee.DepartmentId,
            PostTitleId = employee.PostTitleId,
            IsActive = true,
            DateCreated = DateTime.Now,
            DateModified = DateTime.Now,
            Status = EntryStatus.Inserted
        };

        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync(cancellationToken);

        return await GetEmployeeById(newEmployee.Id, cancellationToken);
    }

    public async Task<EmployeeResponseDto> UpdateEmployee(int Id, EmployeeRequestDto employee, CancellationToken cancellationToken)
    {
        var existingEmployee = await _context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == Id && x.Status != EntryStatus.Deleted, cancellationToken);

        NotFoundException.ThrowIfNull(existingEmployee, EntityType.Employee);

        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName.ToUpper();
        existingEmployee.OtherName = employee.OtherName;
        existingEmployee.DateOfBirth = employee.DateOfBirth;
        existingEmployee.Email = employee.Email;
        existingEmployee.DateJoined = employee.DateJoined;
        existingEmployee.DepartmentId = employee.DepartmentId;
        existingEmployee.PostTitleId = employee.PostTitleId;
        existingEmployee.DateModified = DateTime.Now;
        existingEmployee.Status = EntryStatus.Modified;

        _context.Employees.Update(existingEmployee);
        await _context.SaveChangesAsync(cancellationToken);

        return await GetEmployeeById(Id, cancellationToken);
    }

    public async Task DeactivateEmployee(int Id, CancellationToken cancellationToken)
    {
        var existingEmployee = await _context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == Id && x.Status != EntryStatus.Deleted, cancellationToken);

        NotFoundException.ThrowIfNull(existingEmployee, EntityType.Employee);

        existingEmployee.IsActive = false;
        existingEmployee.DateModified = DateTime.Now;
        existingEmployee.Status = EntryStatus.Modified;

        _context.Employees.Update(existingEmployee);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
