using Microsoft.EntityFrameworkCore;

namespace Mini_CRM_Blazor.Server.DAL.Base
{
    public class BaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T[]> GetAll()
        {
            return await _dbContext.Set<T>().ToArrayAsync();
        }

        public virtual async Task<T?> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T?> Add(T newEntity)
        {
            _dbContext.Set<T>().Add(newEntity);
            await _dbContext.SaveChangesAsync();
            return newEntity;
        }

        public virtual async Task<T?> Update(T newEntity)
        {
            _dbContext.Set<T>().Update(newEntity);
            await _dbContext.SaveChangesAsync();
            return newEntity;
        }
    }
}
