using FinanceAPI.Application.PostTitle.DTOs;
using MediatR;

namespace FinanceAPI.Application.PostTitle.Queries;
public record GetPostTitlesQuery : IRequest<List<PostTitleResponseDto>>;
