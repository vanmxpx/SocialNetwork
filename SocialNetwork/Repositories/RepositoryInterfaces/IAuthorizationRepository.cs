using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface IAuthorizationRepository : IGenericRepository<Authorization>
    {
         Task<Authorization> GetById(int id);
    }
}