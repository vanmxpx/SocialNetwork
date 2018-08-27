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
                .Include(s => s.Subscriber)
                .ToListAsync();
        }
        public async Task<List<Followings>> GetBlogersById(int idSuscriber)
        {
            return await Context.Set<Followings>()
                .AsNoTracking()
                .Where(e => e.SubscriberRef == idSuscriber)
                .Include(b => b.Blogger)
                .ToListAsync();
        }

        public async Task<List<Followings>> GetBlogersByIdWithPosts(int idSuscriber)
        {
            return await Context.Set<Followings>()
                .AsNoTracking()
                .Where(e => e.SubscriberRef == idSuscriber)
                .Include(b => b.Blogger)
                .ThenInclude(p => p.Posts)
                .ThenInclude(pr => pr.Profile)
                .ToListAsync();
        }

        public void Delete(Followings Followings)
        {
            Context.Set<Followings>().Remove(Followings);
        }
    }
}