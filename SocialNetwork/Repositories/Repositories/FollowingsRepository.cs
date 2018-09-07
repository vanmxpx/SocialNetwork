using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;
using SocialNetwork.Repositories.GenericRepository;
using SocialNetwork;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Repositories
{
    public class FollowingsRepository : GenericRepository<Followings>, IFollowingsRepository
    {
        public FollowingsRepository(ShortyContext context) : base(context)
        {

        }

        public void Delete(Followings Followings)
        {
            Context.Set<Followings>().Remove(Followings);
        }
    }
}