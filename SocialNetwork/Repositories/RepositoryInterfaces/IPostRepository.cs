using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
       Task<Post> GetById(int id);
        Task<List<Post>> GetByAuthorId(int id);
        Task<List<Post>> GetByAuthorIdAndPage(int id, int page);
        Task<List<Post>> GetNewsById(int idSuscriber);
        Task<List<Post>> GetNewsByIdAndPage(int idSuscriber, int page);
        void Delete(Post post);
    }
}
