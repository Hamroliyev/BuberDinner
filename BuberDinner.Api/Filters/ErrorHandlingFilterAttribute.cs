using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Type = "https://httpstatuses.org/500",
            Title = "An error occured while processing your request.",
            Status = 500
        };

        context.Result = new ObjectResult(problemDetails);
        
        context.ExceptionHandled = true;
    }
}