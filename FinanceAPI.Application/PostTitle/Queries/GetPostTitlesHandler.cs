using FinanceAPI.Application.PostTitle.DTOs;
using MediatR;

namespace FinanceAPI.Application.PostTitle.Queries;
public class GetPostTitlesHandler(IPostTitles postTitles) : IRequestHandler<GetPostTitlesQuery, List<PostTitleResponseDto>>
{
    public async Task<List<PostTitleResponseDto>> Handle(GetPostTitlesQuery query, CancellationToken cancellationToken)
    {
        return await postTitles.GetPostTitles(cancellationToken);
    }
}
