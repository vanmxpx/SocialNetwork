using System.Threading.Tasks;

namespace SocialNetwork.Repositories
{
    public interface IUnitOfWork
    {
        PostRepository PostRepository { get; }
        ProfileRepository ProfileRepository { get; }
        AuthorizationRepository AuthorizationRepository { get; }
        CredentialRepository CredentialRepository { get; }
        FollowingsRepository FollowingsRepository { get; }
        Task Save();
    }
}