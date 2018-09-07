using System;
using System.Threading.Tasks;
using SocialNetwork.Models;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ShortyContext context;
        public UnitOfWork(ShortyContext context)
        {
            this.context = context; 
        }
        
        private IPostRepository postRepository;
        private IProfileRepository profileRepository;
        private ICredentialRepository credentialRepository;
        private IAuthorizationRepository authorizationRepository;
        private IFollowingsRepository followingsRepository;

        public IPostRepository PostRepository
        {
            get
            {
                if (this.postRepository == null)
                {
                    this.postRepository = new PostRepository(context);
                }
                return postRepository;
            }
        }

        public IProfileRepository ProfileRepository
        {
            get
            {
                if (this.profileRepository == null)
                {
                    this.profileRepository = new ProfileRepository(context);
                }
                return profileRepository;
            }
        }

        public IAuthorizationRepository AuthorizationRepository
        {
            get
            {
                if (this.authorizationRepository == null)
                {
                    this.authorizationRepository = new AuthorizationRepository(context);
                }
                return authorizationRepository;
            }
        }

        public ICredentialRepository CredentialRepository
        {
            get
            {
                if (this.credentialRepository == null)
                {
                    this.credentialRepository = new CredentialRepository(context);
                }
                return credentialRepository;
            }
        }

        public IFollowingsRepository FollowingsRepository
        {
            get
            {
                if (this.followingsRepository == null)
                {
                    this.followingsRepository = new FollowingsRepository(context);
                }
                return followingsRepository;
            }
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}