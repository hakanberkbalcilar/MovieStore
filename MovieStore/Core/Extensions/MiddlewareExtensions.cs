using MovieStore.Core.Middlewares;

namespace MovieStore.Core.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder) => builder.UseMiddleware<CustomExceptionMiddleware>();
}