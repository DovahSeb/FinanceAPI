using FinanceAPI.Application.Employee;
using FinanceAPI.Application.Employee.DTOs;
using FinanceAPI.Application.Employee.Queries.GetEmployees;
using NSubstitute;

namespace FinanceAPI.Application.Tests.Unit.Employee.Queries;
public class GetEmployeesHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnActiveEmployees()
    {
        // Arrange
        var query = new GetEmployeesQuery();
        var mockRepository = Substitute.For<IEmployee>();
        var handler = new GetEmployeesHandler(mockRepository);
        var cancellationToken = CancellationToken.None;

        var expectedEmployees = new List<EmployeeResponseDto>
        {
            new EmployeeResponseDto(1, "John", "Doe", new DateOnly(1990, 5, 15), "john.doe@finance.gov.sc", new DateOnly(2023, 6, 1), "Office of the Minister", "Principal Secretary", true),
            new EmployeeResponseDto(2, "Jane", "Smith", new DateOnly(1995, 8, 21), "jane.smith@finance.gov.sc", new DateOnly(2022, 3, 10), "HR Department", "HR Officer", true)
        };

        mockRepository.GetEmployees(cancellationToken).Returns(expectedEmployees);

        // Act
        var result = await handler.Handle(query, cancellationToken);

        // Assert
        await mockRepository.Received(1).GetEmployees(cancellationToken);

        Assert.NotNull(result);
        Assert.IsType<List<EmployeeResponseDto>>(result);
        Assert.Equal(2, result.Count);

        Assert.Equal("John", result[0].FirstName);
        Assert.Equal("Doe", result[0].LastName);
        Assert.Equal("john.doe@finance.gov.sc", result[0].Email);
        Assert.True(result[0].IsActive);

        Assert.Equal("Jane", result[1].FirstName);
        Assert.Equal("Smith", result[1].LastName);
        Assert.Equal("jane.smith@finance.gov.sc", result[1].Email);
        Assert.True(result[1].IsActive);
    }

}
