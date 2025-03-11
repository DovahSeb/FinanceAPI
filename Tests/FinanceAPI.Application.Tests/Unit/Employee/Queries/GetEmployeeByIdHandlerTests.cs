using FinanceAPI.Application.Employee;
using FinanceAPI.Application.Employee.DTOs;
using FinanceAPI.Application.Employee.Queries.GetEmployeeById;
using NSubstitute;

namespace FinanceAPI.Application.Tests.Unit.Employee.Queries;
public class GetEmployeeByIdHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnEmployee_WhenIdIsValid()
    {
        //Arrange
        var request = new GetEmployeeByIdQuery(1);
        var mockrepository = Substitute.For<IEmployee>();
        var handler = new GetEmployeeByIdHandler(mockrepository);
        var cancellationToken = CancellationToken.None;

        var expectedEmployee = new EmployeeResponseDto(1, "John", "Doe", new DateOnly(1990, 5, 15), "john.doe@finance.gov.sc", new DateOnly(2023, 6, 1), "Office of the Minister", "Principal Secretary", true);

        mockrepository.GetEmployeeById(Arg.Is<int>(id => id == 1), cancellationToken).Returns(expectedEmployee);

        //Act

        var result = await handler.Handle(request, cancellationToken);

        //Assert

        await mockrepository.Received(1).GetEmployeeById(Arg.Is<int>(id => id == 1), cancellationToken);

        Assert.NotNull(result);
        Assert.IsType<EmployeeResponseDto>(result);
        Assert.Equal("John", result.FirstName);
        Assert.Equal("Doe", result.LastName);
        Assert.Equal("john.doe@finance.gov.sc", result.Email);
        Assert.True(result.IsActive);
    }
}
