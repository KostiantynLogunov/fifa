using FIFA.Application.Common.Excaptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace FIFA.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) => _next = next;
     
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (ex)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException notFoundException: 
                    code = HttpStatusCode.NotFound;
                    break;    
            }

            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";

            if (result == string.Empty) 
            {
                result = JsonSerializer.Serialize(new {errpr = ex.Message});
            }

            return context.Response.WriteAsync(result);
        }
    }
}
