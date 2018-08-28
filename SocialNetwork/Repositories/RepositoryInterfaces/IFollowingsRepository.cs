using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface IFollowingsRepository : IGenericRepository<Followings>
    {
        void Delete(Followings followings);
    }
}
