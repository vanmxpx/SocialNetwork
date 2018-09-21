using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;
using SocialNetwork;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(ShortyContext context) : base(context)
        {

        }

        public async Task<Post> GetById(int id)
        {
            return await Context.Set<Post>()
                .AsNoTracking()
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<List<Post>> GetByAuthorId(int id)
        {
            return await Context.Set<Post>()
                .AsNoTracking()
                .Where(e => e.ProfileRef == id)
                .Include(p => p.Profile)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<List<Post>> GetByAuthorIdAndPage(int id, int page)
         {
            var pageSize = 5;
            var skip = pageSize * (page - 1);

            List<Post> posts = await GetByAuthorId(id);

            return posts
                .OrderByDescending(p => p.Id)
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }

        public async Task<List<Post>> GetNewsById(int idSuscriber)
        {
            List<Followings> followings = await Context.Set<Followings>()
            .AsNoTracking()
            .Where(e => e.SubscriberRef == idSuscriber)
            .Include(b => b.Blogger)
            .ThenInclude(p => p.Posts)
            .ThenInclude(pr => pr.Profile)
            .ToListAsync();

            List<Post> posts = new List<Post>();
            if (followings != null)
            {
                foreach (Followings following in followings)
                {
                    posts.AddRange(following.Blogger.Posts);
                }
            }
            return posts
                    .OrderByDescending(p => p.Id)
                    .Take(100)
                    .ToList();
        }

        public async Task<List<Post>> GetNewsByIdAndPage(int idSuscriber, int page)
        {
            var pageSize = 5;
            var skip = pageSize * (page - 1);

            List<Followings> followings = await Context.Set<Followings>()
            .AsNoTracking()
            .Where(e => e.SubscriberRef == idSuscriber)
            .Include(b => b.Blogger)
            .ThenInclude(p => p.Posts)
            .ThenInclude(pr => pr.Profile)
            .ToListAsync();

            List<Post> posts = new List<Post>();
            if (followings != null)
            {
                foreach (Followings following in followings)
                {
                    posts.AddRange(following.Blogger.Posts);
                }
            }

            return posts
                    .OrderByDescending(p => p.Id)
                    .Skip(skip)
                    .Take(pageSize)
                    .ToList();
        }

        public void Delete(Post post)
        {
            Context.Set<Post>().Remove(post);
        }
    }
}
