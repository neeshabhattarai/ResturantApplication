using ResturantApplication.Domain.Exception;

namespace RestuarantApplication.Api.Extensions;
public class ExceptionHandler:IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            return next(context);
        }
        catch (NotFoundException exception)
        {
            context.Response.StatusCode = 404;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(exception.Message);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            return context.Response.WriteAsync(ex.Message);
        }
        
    }
}

