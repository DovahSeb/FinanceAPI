using FinanceAPI.Application.PostTitle.DTOs;

namespace FinanceAPI.Application.PostTitle;
public interface IPostTitles
{
    Task<List<PostTitleResponseDto>> GetPostTitles(CancellationToken cancellationToken);
}
