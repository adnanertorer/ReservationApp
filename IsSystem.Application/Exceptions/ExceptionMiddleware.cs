using IsSystem.Application.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;

namespace IsSystem.Application.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    private readonly HttpExceptionHandler _exceptionHandler;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
        _exceptionHandler = new HttpExceptionHandler();
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }catch (Exception exception)
        {
            await HandleException(context.Response, exception);
        }
    }

    private Task HandleException(HttpResponse httpResponse, Exception exception)
    {
       httpResponse.ContentType = "application/json";
        _exceptionHandler.Response = httpResponse;
        return _exceptionHandler.HandleExceptionAsync(exception);
    }
}
