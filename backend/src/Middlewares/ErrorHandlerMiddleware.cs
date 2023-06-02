namespace backend.src.Middlewares;

using backend.src.Helpers;
using Microsoft.EntityFrameworkCore;

public class ErrorHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CustomizedException e)
        {
            await context.Response.WriteAsJsonAsync(new {
                StatusCode = e.StatusCode,
                Message = e.Message
            });
        }
        catch (DbUpdateException e)
        {
            await context.Response.WriteAsJsonAsync(new {
                StatusCode = 500,
                Message = e.InnerException!.Message
            });
        }
        catch (Exception e)
        {
            await context.Response.WriteAsJsonAsync(new {
                StatusCode = 500,
                Message = e.Message
            });
        }
    }
}
