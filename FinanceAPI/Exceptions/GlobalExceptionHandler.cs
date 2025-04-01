using FinanceAPI.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

using System.Diagnostics;

namespace FinanceAPI.Exceptions;

public class GlobalExceptionHandler() : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpcontext, Exception exception, CancellationToken cancellationtToken)
    {
        var traceId = Activity.Current?.Id ?? httpcontext.TraceIdentifier;

        var (statusCode, title) = MapException(exception);

        await Results.Problem(
            title: title,
            statusCode: statusCode,
            extensions: new Dictionary<string, object?>
            {
                {"traceId", traceId }
            }
        ).ExecuteAsync(httpcontext);

        return true;
    }

    private static(int StatusCode, string Title) MapException(Exception exception)
    {
        return exception switch
        {
            ArgumentOutOfRangeException => (StatusCodes.Status400BadRequest, exception.Message),
            NotFoundException => (StatusCodes.Status404NotFound, exception.Message),
            _ => (StatusCodes.Status500InternalServerError, "Please contact support")
        };
    }
}
