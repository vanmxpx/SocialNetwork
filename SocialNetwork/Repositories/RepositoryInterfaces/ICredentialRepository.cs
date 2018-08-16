using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface ICredentialRepository : IGenericRepository<Credential>
    {
         Task<Credential> GetByEmail(string email);
         Task<Credential> GetById(int id);
         Task<bool> IsExist(string email);
         void Delete(Credential entity);
    }
}