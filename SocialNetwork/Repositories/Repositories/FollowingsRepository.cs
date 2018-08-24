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

        public async Task<List<Followings>> GetSuscribersById(int idBloger)
        {
            return await Context.Set<Followings>()
                .AsNoTracking()
                .Where(e => e.BloggerRef == idBloger)
                .ToListAsync();
        }
        public async Task<List<Followings>> GetBlogersById(int idSuscriber)
        {
            return await Context.Set<Followings>()
                .AsNoTracking()
                .Where(e => e.SubscriberRef == idSuscriber)
                .ToListAsync();
        }

        public void Delete(Followings Followings)
        {
            Context.Set<Followings>().Remove(Followings);
        }
    }
}