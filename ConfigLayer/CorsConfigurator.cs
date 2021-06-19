using System;
using AbstractionsLayer;
using Microsoft.Extensions.DependencyInjection;


namespace ConfigLayer
{
    public class CorsConfigurator : IServices
    {
        
        public void Initialise(IServiceCollection services)
        {
            try
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("Cors",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                        });
                });
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
