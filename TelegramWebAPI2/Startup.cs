using System.Collections.Generic;
using AbstractionsLayer;
using ConfigLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TelegramWebAPI2
{
    public class Startup
    {
        public List<IServices> Services { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Services = new List<IServices>()
            {
                new ControllersConfigurator(),
                new DbConfigurator(configuration),
                new CorsConfigurator(),
                new IdentityConfigurator(),
                new RazorConfigurator(),
                new SwaggerConfigurator()
            };
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            foreach (var service in Services)
            {
                service.Initialise(services);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
