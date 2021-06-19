using System;
using Microsoft.Extensions.DependencyInjection;
using AbstractionsLayer;


namespace ConfigLayer
{
    public class RazorConfigurator : IServices
    {
        public void Initialise(IServiceCollection services)
        {
            try
            {
                services.AddRazorPages();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
