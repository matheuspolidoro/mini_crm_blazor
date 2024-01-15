using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mini_CRM_Blazor.Server.DAL.Base;
using Mini_CRM_Blazor.Server.Models;

namespace Mini_CRM_Blazor.Server.DAL.Repositories
{

    public class ApplicationUsersRepository : BaseRepository<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ApplicationUsersRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : base(dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);
            return applicationUser;
        }

        public async Task<IList<string>> GetRolesFromUser(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<ApplicationUser?> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

    }
}
