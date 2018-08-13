using System;

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

        // public async void SaveAsync()
        // {
        //     await context.SaveChangesAsync();
        // }
    }
}