namespace FinanceAPI.Application.Employee.DTOs;
public record EmployeeResponseDto(int Id, string FirstName, string LastName, DateOnly DateOfBirth, string Email, DateOnly DateJoined, string Department, string PostTitle, bool IsActive);

