using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Repositories
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(ShortyContext Context) : base(Context)
        {
        }
        public async Task<Profile> GetById(int id)
        {
            return await Context.Set<Profile>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<Profile> GetByLogin(string login)
        {
            return await Context.Set<Profile>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Login == login);
        }
        public async Task<Profile> GetByNameAndLastName(string name, string lastName)
        {
            return await Context.Set<Profile>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Name == name && e.LastName == lastName);
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            Context.Set<Profile>().Remove(entity);
        }
    }
}
