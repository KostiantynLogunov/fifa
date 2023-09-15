using Microsoft.AspNetCore.Builder;

namespace FIFA.WebApi.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
