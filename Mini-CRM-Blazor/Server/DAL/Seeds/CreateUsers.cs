﻿using Microsoft.AspNetCore.Identity;
using Mini_CRM_Blazor.Server.Models;

namespace Mini_CRM_Blazor.Server.DAL.Seeds
{
    public static class CreateUsers
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, WebApplicationBuilder builder)
        {
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Admin", "Manager", "Associate" };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var poweruser = new ApplicationUser
            {
                UserName = builder.Configuration["AdminUserEmail"],
                Email = builder.Configuration["AdminUserEmail"],
                EmailConfirmed = true,
            };

            string userPWD = builder.Configuration["AdminUserPassword"];
            var _user = await UserManager.FindByEmailAsync(builder.Configuration["AdminUserEmail"]);

            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(poweruser, "Admin");

                }
            }
        }

    }
}
