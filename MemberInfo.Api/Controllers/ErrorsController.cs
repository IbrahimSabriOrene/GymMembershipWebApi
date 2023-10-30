using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers;

[Route("/error")]
public class ErrorsController : ControllerBase
{
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception != null)
        {
            return Problem(
                title: exception.Message,
                statusCode: (int)exception.HResult,
                detail: exception.StackTrace,
                instance: exception.Source);
        }

        return Problem();
    }
}
