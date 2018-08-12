using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Repositories
{
    public class CredentialRepository : GenericRepository<Credential>, ICredentialRepository
    {
        public CredentialRepository(ShortyContext context) : base(context)
        { }

        public async Task<Credential> GetByEmail(string email)
        {
            return await Context.Set<Credential>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}