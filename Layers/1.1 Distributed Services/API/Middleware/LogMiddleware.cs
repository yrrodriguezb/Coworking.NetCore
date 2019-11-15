using Coworking.API.Middleware;


namespace Microsoft.AspNetCore.Builder
{
    public static class LogMiddleware
    {
        public static IApplicationBuilder UseLogApplicationInsights(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<Log>();

            return builder;
        }
    }
}