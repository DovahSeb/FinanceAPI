using FinanceAPI.Application.Employee.DTOs;
using MediatR;

namespace FinanceAPI.Application.Employee.Commands.UpdateEmployee;
public sealed record UpdateEmployeeCommand(int Id, string FirstName, string OtherName, string LastName, DateOnly DateOfBirth, string Email, DateOnly DateJoined, int DepartmentId, int PostTitleId ) : IRequest<EmployeeResponseDto>;
