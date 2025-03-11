using FinanceAPI.Application.Employee.DTOs;
using MediatR;

namespace FinanceAPI.Application.Employee.Queries.GetEmployees;
public record GetEmployeesQuery : IRequest<List<EmployeeResponseDto>>;
