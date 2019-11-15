using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Coworking.API.Middleware
{
    public class Ejemplo
    {
        private readonly RequestDelegate _next;

        public Ejemplo(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Cualquier accion

            await _next(context); // Asignar el contexto al siguiente middleware

            // Vuelve desde el final
        }
    }
}