using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Repositories
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        private readonly ShortyContext _context;
        public ProfileRepository(ShortyContext _context) : base(_context)
        {
            this._context = _context;
        }
        public async Task<Profile> GetById(int id)
        {
            return await _context.Set<Profile>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<Profile>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
