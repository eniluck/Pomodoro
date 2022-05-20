using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

internal class ExceptionHandlingFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var problemDetails = new ProblemDetails
        {
            Type = "https://example.com/unhandled",
            Detail = context.Exception.Message,
            Title = "Неизвестная ошибка",
            Status = 500,
        };

        context.Result = new ObjectResult(problemDetails)
        {
            ContentTypes = { "application/problem+json" },
            StatusCode = problemDetails.Status,
        };
    }
}