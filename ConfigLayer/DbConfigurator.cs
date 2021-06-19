using System;
using AbstractionsLayer;
using DAL.Context;
using HelpersLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ConfigLayer
{
    public class DbConfigurator : IServices
    {
        public IConfiguration Configuration { get; }
        public DbConfigurator(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void Initialise(IServiceCollection services)
        {
            try
            {
                ConnectionStringInstaller.ConnectionString = Configuration.GetConnectionString("TelegramConnection");

                services.AddDbContext<TelegramContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TelegramConnection")));
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
