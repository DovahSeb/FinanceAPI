using FinanceAPI.Application.Department;
using FinanceAPI.Application.Department.DTOs;
using FinanceAPI.Application.Department.Queries;
using NSubstitute;

namespace FinanceAPI.Application.Tests.Unit.Department.Queries;
public class GetDepartmentsHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturn_EmptyList_WhenNoDepartmentsExist()
    {
        //Arrange
        var request = new GetDepartmentsQuery();
        var mockRepository = Substitute.For<IDepartment>();
        var handler = new GetDepartmentsHandler(mockRepository);
        var cancellationToken = CancellationToken.None;

        mockRepository.GetDepartments(cancellationToken).Returns(new List<DepartmentResponseDto>());

        // Act
        var result = await handler.Handle(request, cancellationToken);

        // Assert
        await mockRepository.Received(1).GetDepartments(cancellationToken);

        Assert.NotNull(result);
        Assert.IsType<List<DepartmentResponseDto>>(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task Handle_ShouldReturn_ListOfDepartments()
    {
        //Arrange
        var request = new GetDepartmentsQuery();
        var mockRepository = Substitute.For<IDepartment>();
        var handler = new GetDepartmentsHandler(mockRepository);
        var cancellationToken = CancellationToken.None;

        var expectedDepartments = new List<DepartmentResponseDto>
        {
            new(1, "Office of the Minister")
        };

        mockRepository.GetDepartments(cancellationToken).Returns(expectedDepartments);

        //Act

        var result = await handler.Handle(request, cancellationToken);

        //Assert

        await mockRepository.Received(1).GetDepartments(cancellationToken);

        Assert.NotNull(result);
        Assert.IsType<List<DepartmentResponseDto>>(result);
        Assert.NotEmpty(result);
        Assert.Single(result);
        Assert.Equal(1, result[0].Id);
        Assert.Equal("Office of the Minister", result[0].Name);
    }
}
