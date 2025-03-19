using FinanceAPI.Application.PostTitle;
using FinanceAPI.Application.PostTitle.DTOs;
using FinanceAPI.Infrastructure.Database;
using FinanceAPI.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.Infrastructure.Services;
public sealed class PostTitlesService : IPostTitle
{
    private readonly DatabaseContext _context;

    public PostTitlesService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<PostTitleResponseDto>> GetPostTitles(CancellationToken cancellationToken)
    {
        var postTitles = await _context.PostTitles
            .Where(x => !x.Status.Equals("D"))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var postTitleDto = postTitles
            .Select(x => x.MapToPostTitleResponseDto())
            .ToList();

        if (!postTitleDto.Any())
        {
            return [];
        }

        return postTitleDto;
    }
}
