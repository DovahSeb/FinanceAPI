using FinanceAPI.Application.PostTitle;
using FinanceAPI.Application.PostTitle.DTOs;
using FinanceAPI.Application.PostTitle.Queries;
using NSubstitute;

namespace FinanceAPI.Application.Tests.Unit.PostTitle.Queries;
public class GetPostTitlesHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturn_EmptyList_WhenNoPostTitlesExist()
    {
        //Arrange
        var request = new GetPostTitlesQuery();
        var mockRepository = Substitute.For<IPostTitles>();
        var handler = new GetPostTitlesHandler(mockRepository);
        var cancellationToken = CancellationToken.None;

        mockRepository.GetPostTitles(cancellationToken).Returns(new List<PostTitleResponseDto>());

        //Act
        var result = await handler.Handle(request, cancellationToken);

        //Assert
        await mockRepository.Received(1).GetPostTitles(cancellationToken);

        Assert.NotNull(result);
        Assert.IsType<List<PostTitleResponseDto>>(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task Handle_ShouldReturn_ListOfPostTitles()
    {
        //Arrange
        var request = new GetPostTitlesQuery();
        var mockRepository = Substitute.For<IPostTitles>();
        var handler = new GetPostTitlesHandler(mockRepository);
        var cancellationToken = CancellationToken.None;

        var expectedPostTitles = new List<PostTitleResponseDto>
        {
            new(1, "Secretary of State")
        };

        mockRepository.GetPostTitles(cancellationToken).Returns(expectedPostTitles);

        //Act
        var result = await handler.Handle(request, cancellationToken);

        //Assert
        await mockRepository.Received(1).GetPostTitles(cancellationToken);

        Assert.NotNull(result);
        Assert.IsType<List<PostTitleResponseDto>>(result);
        Assert.NotEmpty(result);
        Assert.Single(result);
        Assert.Equal(1, expectedPostTitles[0].Id);
        Assert.Equal("Secretary of State", expectedPostTitles[0].Name);
    }
}
