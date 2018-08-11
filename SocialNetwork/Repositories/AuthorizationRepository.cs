using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Repositories
{
    public class AuthorizationRepository : GenericRepository<Authorization>, IAuthorizationRepository
    {
        public AuthorizationRepository(ShortyContext context) : base(context)
        {
        }   

        public async Task<Authorization> GetById(int id)
        {
            return await Context.Set<Authorization>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        } 
    }
}