using System;
using Microsoft.Extensions.DependencyInjection;
using AbstractionsLayer;
    


namespace ConfigLayer
{
    public class ControllersConfigurator : IServices
    {
        public void Initialise(IServiceCollection services)
        {
            try
            {
                services.AddControllers();
                services.AddControllersWithViews();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
