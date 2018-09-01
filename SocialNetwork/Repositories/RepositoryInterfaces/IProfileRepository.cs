using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories.GenericRepository
{
    public interface IProfileRepository : IGenericRepository<Profile>
    {
        Task<Profile> GetById(int id);
        
        Task<Profile> GetByLogin(string login);

        Task<List<Profile>> GetByNameAndLastName(string name, string lastName);
        Task<List<Profile>> GetSubscribersById(int idBloger);
        Task<List<Profile>> GetBloggersById(int idSuscriber);
        Task<Profile> GetByCredentialId(int id);
    
        void Delete(Profile profile);
    }    
}
