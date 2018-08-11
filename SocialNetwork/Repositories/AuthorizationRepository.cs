using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Repositories
{
    public class AuthorizationRepository : GenericRepository<Authorization>, IAuthorizationRepository
    {
        private readonly ShortyContext _context;
        public AuthorizationRepository(ShortyContext context) : base(context)
        {
            this._context = context;
        }   

        public async Task<Authorization> GetById(int id)
        {
            return await _context.Set<Authorization>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        } 
    }
}