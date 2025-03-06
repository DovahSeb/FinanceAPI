using FinanceAPI.Application.Employee.DTOs;
using MediatR;

namespace FinanceAPI.Application.Employee.Queries.GetEmployeeById;
public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeResponseDto>;
