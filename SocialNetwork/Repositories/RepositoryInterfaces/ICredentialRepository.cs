using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface ICredentialRepository : IGenericRepository<Credential>
    {
         Task<Credential> GetByEmail(string email);
         Task<Credential> GetById(int id);
         Task<bool> IsExist(string email);
         Task Delete(Credential entity);
        Credential Authenticate(string email, string password);
        bool VerifyPassword(string password, string passwordBD, byte[] salt);
    }
}