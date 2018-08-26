using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface IAuthorizationRepository : IGenericRepository<Authorization>
    {
        Task<Authorization> GetById(int id);
        Task<List<Authorization>> GetAllAuthorizantionsByCredentialId(int id);
        Task Delete(Authorization authorization);
    }
}