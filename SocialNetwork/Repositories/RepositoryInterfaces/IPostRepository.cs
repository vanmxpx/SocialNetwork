using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post> GetById(int id);
    
        Task Delete(int id);
    }
}
