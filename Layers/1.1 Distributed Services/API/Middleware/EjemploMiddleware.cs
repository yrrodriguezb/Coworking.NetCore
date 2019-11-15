using Coworking.API.Middleware;


namespace Microsoft.AspNetCore.Builder
{
    public static class EjemploMiddleware
    {
        public static IApplicationBuilder UseEjemploMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<Ejemplo>();

            return builder;
        }
    }
}