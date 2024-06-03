using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public static class Seed
    {
        public static async Task SeedDataAsync(UserManager<AppUser> userManager, RoleManager<AppUserRole> _roleManager)
        {
            foreach (var item in Enum.GetValues<ApplicationRoleTypes>())
            {
                if (!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    await _roleManager.CreateAsync(new AppUserRole(item.ToString()));
                }
            }

            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Admin",
                    UserName = "admin",
                    Email = "admin@test.com"
                };
                await userManager.CreateAsync(user, "P@ssw0rd");
                await userManager.AddToRoleAsync(user, ApplicationRoleTypes.Admin.ToString());
            }
        }
    }
}