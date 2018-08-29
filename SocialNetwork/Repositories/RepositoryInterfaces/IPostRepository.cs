using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post> GetById(int id);
        Task<List<Post>> GetByAuthorId(int id);
        
        Task<List<Post>> GetNewsById(int idSuscriber);
        void Delete(Post post);
    }
}
