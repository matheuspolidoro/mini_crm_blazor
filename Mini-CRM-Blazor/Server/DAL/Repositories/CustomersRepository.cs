using Microsoft.EntityFrameworkCore;
using Mini_CRM_Blazor.Server.DAL.Base;
using Mini_CRM_Blazor.Server.Models;

namespace Mini_CRM_Blazor.Server.DAL.Repositories
{

    public class CustomersRepository : BaseRepository<Customer>
    {
        public CustomersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Customer>> GetAllByCompanySubscriberId(Guid id)
        {
            return await _dbContext
                .Customers
                .Include(x => x.CustomerContacts)
                .Where(x => x.CompanySubscriberId == id).ToListAsync();
        }

        public override async Task<Customer?> GetById(Guid id)
        {
            return await _dbContext
                .Customers
                .Include(x => x.CustomerContacts)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
