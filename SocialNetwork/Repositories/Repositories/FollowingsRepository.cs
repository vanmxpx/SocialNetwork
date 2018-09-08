using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Followings> GetByBloggerAndSubscriberId(int idBlogger, int idSubscriber)
        {
            return await Context.Set<Followings>()
                .AsNoTracking()
                .Where(f => f.BloggerRef == idBlogger)
                .Where(f => f.SubscriberRef == idSubscriber)
                .FirstOrDefaultAsync();
        }

        public void Delete(Followings Followings)
        {
            Context.Set<Followings>().Remove(Followings);
        }
    }
}