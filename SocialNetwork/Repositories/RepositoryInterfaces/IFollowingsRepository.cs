using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface IFollowingsRepository : IGenericRepository<Followings>
    {
        Task<List<Followings>> GetSuscribersById(int idBloger);
        Task<List<Followings>> GetBlogersById(int idSuscriber);
        void Delete(Followings followings);
    }
}
