using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Repositories
{
    public class CredentialRepository : GenericRepository<Credential>, ICredentialRepository
    {
        public CredentialRepository(ShortyContext context) : base(context)
        { }

        public async Task Delete(Credential Entity)
        {
            Context.Set<Credential>().Remove(Entity);
            await Context.SaveChangesAsync();
        }

        public async Task<Credential> GetByEmail(string email)
        {
            return await Context.Set<Credential>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Credential> GetById(int id)
        {
            return await Context.Set<Credential>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> IsExist(string email)
        {
            if(await GetByEmail(email)!=null)
            return true;
            else
            return false;
        }
    }
}