using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface IFollowingsRepository : IGenericRepository<Followings>
    {
        Task<Followings> GetByBloggerAndSubscriberId(int idBlogger, int idSubscriber);
        void Delete(Followings followings);
    }
}
