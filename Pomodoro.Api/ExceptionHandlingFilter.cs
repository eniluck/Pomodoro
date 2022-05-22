using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

internal class ExceptionHandlingFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var message = context.Exception.ToString();

        var problemDetails = new ProblemDetails
        {
            Type = "https://example.com/unhandled",
            Detail = message,
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