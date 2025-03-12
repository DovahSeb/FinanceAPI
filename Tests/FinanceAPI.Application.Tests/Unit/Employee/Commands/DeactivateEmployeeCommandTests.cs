using FinanceAPI.Application.Employee;
using FinanceAPI.Application.Employee.Commands.DeactivateEmployee;
using NSubstitute;

namespace FinanceAPI.Application.Tests.Unit.Employee.Commands;
public class DeactivateEmployeeCommandTests
{
    [Fact]
    public async Task Handle_ShouldCallDeactivateEmployee()
    {
        // Arrange
        var request = new DeactivateEmployeeCommand(1);
        var mockRepository = Substitute.For<IEmployee>();
        var handler = new DeactivateEmployeeHandler(mockRepository);
        var cancellationToken = CancellationToken.None;

        // Act
        await handler.Handle(request, cancellationToken);

        // Assert
        await mockRepository.Received(1).DeactivateEmployee(request.Id, cancellationToken);
    }

}
