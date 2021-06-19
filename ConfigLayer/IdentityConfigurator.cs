using System;
using AbstractionsLayer;
using DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ModelsLayer;


namespace ConfigLayer
{
    public class IdentityConfigurator : IServices
    {
        public void Initialise(IServiceCollection services)
        {
            try
            {
                services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<IdentityContext>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
