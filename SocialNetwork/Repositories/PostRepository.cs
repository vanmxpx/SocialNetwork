using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;
using SocialNetwork;

namespace SocialNetwork.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(ShortyContext context) : base(context)
        {

        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            Context.Set<Post>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<Post> GetById(int id)
        {
            return await Context.Set<Post>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
