using System.IO;
using Coworking.API.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Coworking.API.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            var xmlPath = Path.Combine(basePath, "Coworking.API.xml");

            services.AddSwaggerGen(config => {
                config.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info {
                    Title = "Coworking API V1",
                    Version = "v1"
                });

                // Habilitar un textbox para ingresar el token cuando el api requiere autenticacion
                config.OperationFilter<AuthorizationHeaderParameterOperationFilter>();

                // Autenticacion Global en Swagger
                // config.AddSecurityDefinition("oauth2", new OAuth2Scheme(){
                //     Description = "Autenticacion OAuth2",
                //     TokenUrl = "https://localhost:5001/api/user/token",
                //     Flow = "password",
                //     Type = "OAuth2"
                // });

                // config.IncludeXmlComments(xmlPath);
            });

            return services;
        } 

        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Coworking API V1");
            });

            return app;
        }
    }
}