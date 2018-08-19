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

        public void Delete(Credential entity)
        {
            // entity.Profile.State = EntityState.Deleted;
            // entity.State = EntityState.Deleted;
            // // var blog = Context.Credentials
            // //     .Include(e => e.Profile).Where
            // //     (c=> c.Id == entity.Id)
            // //     .Single();

            // // Context.Remove(blog);

            // Context.SaveChanges();
            Context.Set<Credential>().Remove(entity);
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