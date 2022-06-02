using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaltaApiYoutube.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BaltaApiYoutube
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Para trabalhar com os controladores
            services.AddControllers();

            // Injeção de dependência
            // Assim estará disponível em todos os métodos que precisar
            services.AddDbContext<AppDataContext>(); // Connection String já está configurada no AppDataContext
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                
            });
        }
    }
}
