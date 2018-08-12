using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Repositories
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        //private readonly ShortyContext Context;
        public ProfileRepository(ShortyContext Context) : base(Context)
        {
            //this.Context = Context;
        }
        public async Task<Profile> GetById(int id)
        {
            return await Context.Set<Profile>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            Context.Set<Profile>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
