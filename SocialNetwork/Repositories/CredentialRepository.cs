using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Repositories
{
    public class CredentialRepository : GenericRepository<Credential>, ICredentialRepository
    {
        private readonly ShortyContext _context;
        public CredentialRepository(ShortyContext context) : base(context)
        {
            this._context = context;
        }   

        public async Task<Credential> GetByLogin(string email)
        {
            return await _context.Set<Credential>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Email == email);
        } 
    }
}