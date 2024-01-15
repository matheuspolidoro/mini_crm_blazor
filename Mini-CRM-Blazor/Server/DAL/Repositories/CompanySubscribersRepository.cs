using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mini_CRM_Blazor.Server.DAL.Base;
using Mini_CRM_Blazor.Server.Models;
using System.Security.Claims;

namespace Mini_CRM_Blazor.Server.DAL.Repositories
{

    public class CompanySubscribersRepository : BaseRepository<CompanySubscriber>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public CompanySubscribersRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager) : base(dbContext)
        {
            _userManager = userManager;
        }

        public async Task<IList<CompanySubscriber>> GetAll()
        {
            return await _dbContext
                .CompanySubscribers
                .Include(x => x.ApplicationUsers).ToListAsync();
        }

        public async Task<CompanySubscriber> Add(CompanySubscriber companySubscriber, ApplicationUser user)
        {
            _dbContext.CompanySubscribers.Add(companySubscriber);
            await _userManager.AddToRoleAsync(user, "Manager");
            await _userManager.AddClaimAsync(user, new Claim("CompanySubscriber", companySubscriber.Id.ToString()));

            await _dbContext.SaveChangesAsync();
            return companySubscriber;
        }

        public override async Task<CompanySubscriber?> GetById(Guid id)
        {
            return await _dbContext
                .CompanySubscribers
                .Include(x => x.ApplicationUsers)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
