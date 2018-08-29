using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;
using System.Text;

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

         public Credential Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var credential = Context.Credentials.SingleOrDefault(x => x.Email == email);

            if (credential == null)
            {
                return null;
            }

            // проверка пароля
            //FIXME: salt? hashpasword?
            //TODO: token, authorization
            //if (!VerifyPassword(password, credential.Password, Encoding.ASCII.GetBytes("salt")))
            if(password!=credential.Password)
            {
                return null;
            }

            // удачная аутентификация
            return credential;
        }

        public bool VerifyPassword(string password, string passwordBD, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (passwordBD.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordBD[i]) return false;
                }
            }

            return true;
        }
    }
}