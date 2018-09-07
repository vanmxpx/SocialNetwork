using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Models;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ShortyContext Context;
    
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
        }

        public void Update(int id, TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }
    }
}
