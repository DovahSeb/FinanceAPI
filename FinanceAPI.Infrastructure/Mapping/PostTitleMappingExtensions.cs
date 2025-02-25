using FinanceAPI.Application.PostTitle.DTOs;
using FinanceAPI.Domain.Models;

namespace FinanceAPI.Infrastructure.Mapping;
public static class PostTitleMappingExtensions
{
    public static PostTitleResponseDto MapToPostTitleResponseDto(this PostTitle postTitle)
    {
        return new PostTitleResponseDto(postTitle.Id, postTitle.Name);
    }
}
