using FinanceAPI.Application.Employee;
using FinanceAPI.Application.Employee.Commands.UpdateEmployee;
using FinanceAPI.Application.Employee.DTOs;
using NSubstitute;

namespace FinanceAPI.Application.Tests.Unit.Employee.Commands;
public class UpdateEmployeeCommandTests
{
    [Fact]
    public async Task Handle_ShouldUpdateEmployee_WhenValidRequest()
    {
        // Arrange
        var request = new UpdateEmployeeCommand(1, "John", "Doe", new DateOnly(1990, 5, 15), "john.doe@finance.gov.sc", new DateOnly(2023, 6, 1), 1, 2);
        var mockRepository = Substitute.For<IEmployee>();
        var handler = new UpdateEmployeeHandler(mockRepository);
        var cancellationToken = CancellationToken.None;

        var expectedResponse = new EmployeeResponseDto(request.Id, request.FirstName, request.LastName, request.DateOfBirth, request.Email, request.DateJoined, "Office of the Minister", "Principal Secretary", true);

        mockRepository.UpdateEmployee(
            request.Id,
            Arg.Is<EmployeeRequestDto>(dto =>
            dto.FirstName == request.FirstName &&
            dto.LastName == request.LastName &&
            dto.DateOfBirth == request.DateOfBirth &&
            dto.Email == request.Email &&
            dto.DateJoined == request.DateJoined &&
            dto.DepartmentId == request.DepartmentId &&
            dto.PostTitleId == request.PostTitleId
        ), cancellationToken).Returns(expectedResponse);

        // Act
        var result = await handler.Handle(request, cancellationToken);

        // Assert
        await mockRepository.Received(1).UpdateEmployee(
            request.Id,
            Arg.Is<EmployeeRequestDto>(dto =>
            dto.FirstName == request.FirstName &&
            dto.LastName == request.LastName &&
            dto.DateOfBirth == request.DateOfBirth &&
            dto.Email == request.Email &&
            dto.DateJoined == request.DateJoined &&
            dto.DepartmentId == request.DepartmentId &&
            dto.PostTitleId == request.PostTitleId
        ), cancellationToken);

        Assert.NotNull(result);
        Assert.IsType<EmployeeResponseDto>(result);
        Assert.Equal(request.Id, result.Id);
        Assert.Equal(request.FirstName, result.FirstName);
        Assert.Equal(request.LastName, result.LastName);
        Assert.Equal(request.DateOfBirth, result.DateOfBirth);
        Assert.Equal(request.Email, result.Email);
    }
}
