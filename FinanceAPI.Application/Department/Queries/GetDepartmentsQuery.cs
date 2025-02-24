using FinanceAPI.Application.Department.DTOs;
using MediatR;

namespace FinanceAPI.Application.Department.Queries;

public record GetDepartmentsQuery : IRequest<List<DepartmentResponseDto>>;
