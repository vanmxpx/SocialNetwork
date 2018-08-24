using System;
using System.Threading.Tasks;

namespace SocialNetwork.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ShortyContext context;
        public UnitOfWork(ShortyContext context)
        {
            this.context = context; 
        }
        
        private PostRepository postRepository;
        private ProfileRepository profileRepository;
        private CredentialRepository credentialRepository;
        private AuthorizationRepository authorizationRepository;
        private FollowingsRepository followingsRepository;

        public PostRepository PostRepository
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

        public ProfileRepository ProfileRepository
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

        public AuthorizationRepository AuthorizationRepository
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

        public CredentialRepository CredentialRepository
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

        public FollowingsRepository FollowingsRepository
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