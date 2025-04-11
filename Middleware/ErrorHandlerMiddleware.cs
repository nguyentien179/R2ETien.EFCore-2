using System;
using System.Net;
using System.Text.Json;

namespace R2ETien.EFCore.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var response = context.Response;
        var statusCode = HttpStatusCode.InternalServerError;
        string message = exception.Message;

        switch (exception)
        {
            case InvalidOperationException:
                statusCode = HttpStatusCode.BadRequest;
                message = exception.Message;
                break;

            case ArgumentNullException:
                statusCode = HttpStatusCode.BadRequest;
                message = exception.Message;
                break;

            case KeyNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                message = exception.Message;
                break;
        }

        response.StatusCode = (int)statusCode;

        var result = JsonSerializer.Serialize(
            new { error = message, statusCode = response.StatusCode }
        );

        return context.Response.WriteAsync(result);
    }
}
