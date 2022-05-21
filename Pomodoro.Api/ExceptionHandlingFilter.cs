using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

internal class ExceptionHandlingFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var message = context.Exception.Message;
        if (context.Exception.InnerException != null)
        {
            message += $" Inner exception: {context.Exception.InnerException.Message}";
        }

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