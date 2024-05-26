using System.Net;
using Newtonsoft.Json;
using QuestionnaireServices.ErrorModels;

namespace QuestionnarieApplication.Middlewares;

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
        catch (Exception exp)
        {
            if (exp is ErrorException)
            {
                var errorException = exp as ErrorException;
                
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)errorException.Code;

                var error = new ErrorModel()
                {
                    Message = errorException.Message,
                    Code = errorException.Code
                };
                
                await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
                return;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}