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
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<List<Post>> GetByAuthorId(int id)
        {
            return await Context.Set<Post>()
                .AsNoTracking()
                .Where(e => e.ProfileRef == id)
                .ToListAsync();
        }

        public void Delete(Post post)
        {
            Context.Set<Post>().Remove(post);
        }
    }
}
