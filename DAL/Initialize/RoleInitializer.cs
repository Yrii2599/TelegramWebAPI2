using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ModelsLayer;

namespace DAL.Initialize
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) 
        {
            string adminEmail = "admin@gmail.com";
            string adminName = "admin";
            string adminPassword = "Admin@123";
            string admin = "Administrator";
            string user = "User";

            var adminRole = new IdentityRole(admin) ;
            var userRole = new IdentityRole(admin) ;

            if (await roleManager.FindByNameAsync(admin) == null)
            {
                await roleManager.CreateAsync(adminRole);
            }

            if (await roleManager.FindByNameAsync(user) == null)
            {
                await roleManager.CreateAsync(userRole);
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User adminUser = new User { Email = adminEmail, UserName = adminName };
                IdentityResult result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, admin);
                }
            }
        }
    }
}
