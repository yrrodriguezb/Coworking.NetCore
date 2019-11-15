using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Api.CrossCutting.Register;
using Api.DataAccess.Contracts;
using Coworking.API.Config;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICoworkingDataContext, CoworkingDataContext>();

            services.AddDbContext<CoworkingDataContext>(options => {
                //options.UseSqlServer(Configuration.GetConnectionString("DataBaseCoworking"));
                options.UseSqlite("Data Source=coworking.db");
            });

            IoCRegister.AddRegistration(services);
            SwaggerConfig.AddRegistration(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            SwaggerConfig.AddRegistration(app);
            app.UseEjemploMiddleware();
            // app.UseLogApplicationInsights(); -- Realizar configuracion Previa
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
