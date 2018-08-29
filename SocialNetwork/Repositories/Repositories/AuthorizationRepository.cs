using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Repositories
{
    public class AuthorizationRepository : GenericRepository<Authorization>, IAuthorizationRepository
    {
        public AuthorizationRepository(ShortyContext context) : base(context)
        { }

        public async Task<Authorization> GetById(int id)
        {
            return await Context.Set<Authorization>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Authorization>> GetAllAuthorizantionsByCredentialId(int id)
        {
            return await Context.Set<Authorization>()
                .AsNoTracking()
                .Where(e => e.CredentialRef == id)
                .ToListAsync();
        }

        public async Task Delete(Authorization authorization){
            Context.Set<Authorization>().Remove(authorization);
            await Context.SaveChangesAsync();
        }
    }
}