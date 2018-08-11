using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ShortyContext Context;
    
        public GenericRepository(ShortyContext Context)
        {
            this.Context = Context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsNoTracking();
        }

        public async Task Create(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
