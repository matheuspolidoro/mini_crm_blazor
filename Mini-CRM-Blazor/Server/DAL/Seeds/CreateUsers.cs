using Microsoft.AspNetCore.Identity;
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

       
         public static async Task CreateCompanies()
         {
            var companies = new List<CompanySubscriber> {
                new() {
                    Id = Guid.NewGuid(),
                    CompanyName = "Xpto Corporation, Inc.",
                    TradingName = "Xpto",
                    Website = "www.xpto.com",
                    AreaOfBusiness = "Technology",
                    Description = "A good description here",
                    AssociateMembers = new List<AssociateMember>
                    {
                        new AssociateMember
                        {
                            Id = Guid.NewGuid(),
                            Email = "member1@xpto.com",
                            PhoneNumber = "1234567890",
                            Name = "Julio Almeida",
                            Position = "Position A"
                        }
                    }

                },
                new() {
                    Id = Guid.NewGuid(),
                    CompanyName = "Orange Computer, Inc..",
                    TradingName = "Orange",
                    Website = "www.orange.com",
                    AreaOfBusiness = "Technology",
                    Description = "A good description here"
                },
            };
        }
    }
}
