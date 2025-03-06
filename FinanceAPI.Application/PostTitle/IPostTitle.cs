using FinanceAPI.Application.PostTitle.DTOs;

namespace FinanceAPI.Application.PostTitle;
public interface IPostTitle
{
    Task<List<PostTitleResponseDto>> GetPostTitles(CancellationToken cancellationToken);
}
