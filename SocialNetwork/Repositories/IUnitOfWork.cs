using System.Threading.Tasks;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Repositories
{
    public interface IUnitOfWork
    {
        IPostRepository PostRepository { get; }
        IProfileRepository ProfileRepository { get; }
        IAuthorizationRepository AuthorizationRepository { get; }
        ICredentialRepository CredentialRepository { get; }
        IFollowingsRepository FollowingsRepository { get; }
        Task Save();
    }
}