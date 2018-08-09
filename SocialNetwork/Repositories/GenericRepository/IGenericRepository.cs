using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
    
        Task Create(TEntity entity);
    
        Task Update(int id, TEntity entity);
    }
}
