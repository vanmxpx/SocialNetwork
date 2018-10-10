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
        List<Profile> GetCoincidentallyLogin(string login, int skip, int take);
        List<Profile> GetCoincidentallyName(string name, string lastName, int skip, int take);
    
        void Delete(Profile profile);
    }    
}
