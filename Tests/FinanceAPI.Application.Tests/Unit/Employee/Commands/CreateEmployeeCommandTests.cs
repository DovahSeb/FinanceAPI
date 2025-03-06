using FinanceAPI.Application.Employee;
using FinanceAPI.Application.Employee.Commands.CreateEmployee;
using FinanceAPI.Application.Employee.DTOs;
using NSubstitute;

namespace FinanceAPI.Application.Tests.Unit.Employee.Commands;
public class CreateEmployeeCommandTests
{
    [Fact]
    public async Task Handle_ShouldCreateNewEmployee_WhenValidRequest()
    {
        //Arrange
        var request = new CreateEmployeeCommand("John", "Doe", new DateOnly(1990, 5, 15), "john.doe@finance.gov.sc", new DateOnly(2023, 6, 1), 1, 2);
        var mockRepository = Substitute.For<IEmployee>();
        var handler = new CreateEmployeeHandler(mockRepository);
        var cancellationToken = CancellationToken.None;

        var expectedResponse = new EmployeeResponseDto(1, request.FirstName, request.LastName, request.DateOfBirth, request.Email, request.DateJoined, "Office of the Minister", "Principal Secretary", true);

        mockRepository.CreateEmployee(Arg.Is<EmployeeRequestDto>(dto =>
            dto.FirstName == request.FirstName &&
            dto.LastName == request.LastName &&
            dto.DateOfBirth == request.DateOfBirth &&
            dto.Email == request.Email &&
            dto.DateJoined == request.DateJoined &&
            dto.DepartmentId == request.DepartmentId &&
            dto.PostTitleId == request.PostTitleId
        ), cancellationToken).Returns(expectedResponse);


        //Act
        var result = await handler.Handle(request, cancellationToken);

        //Assert
        await mockRepository.Received(1).CreateEmployee(Arg.Is<EmployeeRequestDto>(dto =>
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
        Assert.Equal(request.FirstName, result.FirstName);
        Assert.Equal(request.LastName, result.LastName);
        Assert.Equal(request.DateOfBirth, result.DateOfBirth);
        Assert.Equal(request.Email, result.Email);
        Assert.True(result.IsActive);
    }
}
