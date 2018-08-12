using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface IProfileRepository : IGenericRepository<Profile>
    {
        Task<Profile> GetById(int id);
    
        Task Delete(int id);
    }    
}
