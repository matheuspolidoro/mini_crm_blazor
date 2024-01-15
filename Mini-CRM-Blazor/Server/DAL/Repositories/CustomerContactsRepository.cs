using Microsoft.EntityFrameworkCore;
using Mini_CRM_Blazor.Server.DAL.Base;
using Mini_CRM_Blazor.Server.Models;

namespace Mini_CRM_Blazor.Server.DAL.Repositories
{

    public class CustomerContactsRepository : BaseRepository<CustomerContact>
    {
        public CustomerContactsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<CustomerContact>> GetAllByCustomerId(Guid id)
        {
            return await _dbContext
                .CustomerContacts
                .Where(x => x.CustomerId == id).ToListAsync();
        }
    }
}
