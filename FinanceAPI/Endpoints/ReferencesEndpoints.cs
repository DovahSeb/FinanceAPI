using FinanceAPI.Application.Department.DTOs;
using FinanceAPI.Application.Department.Queries;
using FinanceAPI.Application.PostTitle.DTOs;
using FinanceAPI.Application.PostTitle.Queries;
using MediatR;

namespace FinanceAPI.Endpoints;

public static class ReferencesEndpoints
{
    public static WebApplication MapReferencesEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/references")
            .WithTags("References")
            .WithOpenApi();

        root.MapGet("/GetDepartments/", GetDepartments)
            .Produces<List<DepartmentResponseDto>>()
            .WithName("Get Departments")
            .WithSummary("Get Departments Reference Values");

        root.MapGet("/GetPostTitles/", GetPostTitles)
            .Produces<List<PostTitleResponseDto>>()
            .WithName("Get PostTitles")
            .WithSummary("Get Post Titles Reference Values");

        return app;
    }

    public static async Task<IResult> GetDepartments(IMediator mediator)
    {
        return Results.Ok(await mediator.Send(new GetDepartmentsQuery()));
    }

    public static async Task<IResult> GetPostTitles(IMediator mediator)
    {
        return Results.Ok(await mediator.Send(new GetPostTitlesQuery()));
    }
}
