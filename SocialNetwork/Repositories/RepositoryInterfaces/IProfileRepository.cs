using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface IProfileRepository : IGenericRepository<Profile>
    {
        Task<Profile> GetById(int id);
        
        Task<Profile> GetByLogin(string login);

        Task<Profile> GetByNameAndLastName(string name, string lastName);
    
        Task Delete(int id);
    }    
}
