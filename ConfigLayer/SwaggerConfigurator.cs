using System;
using Microsoft.Extensions.DependencyInjection;
using AbstractionsLayer;


namespace ConfigLayer
{
    public class SwaggerConfigurator: IServices
    {
 
        public void Initialise(IServiceCollection services)
        {
            try
            {
                services.AddSwaggerGen();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
