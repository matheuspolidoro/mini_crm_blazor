using Microsoft.EntityFrameworkCore;
using Mini_CRM_Blazor.Server.DAL.Base;
using Mini_CRM_Blazor.Server.Models;

namespace Mini_CRM_Blazor.Server.DAL.Repositories
{

    public class CompanySubscribersRepository : BaseRepository<CompanySubscriber>
    {
        public CompanySubscribersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<CompanySubscriber>> GetAll()
        {
            return await _dbContext
                .CompanySubscribers
                .Include(x => x.AssociateMembers).ToListAsync();
        }

        public override async Task<CompanySubscriber?> GetById(Guid id)
        {
            return await _dbContext
                .CompanySubscribers
                .Include(x => x.AssociateMembers)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
