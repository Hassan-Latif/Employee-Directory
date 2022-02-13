using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EmplyeeDirectory
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager,
                               RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                };

                var result = userManager.CreateAsync(user, "ch@ba999OOH").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
