using AutoMapper;

namespace SocialNetwork
{
    public class AutoMapperPost : AutoMapper.Profile
    {
        public AutoMapperPost()
        {
            CreateMap<Post, PostDto>();
            CreateMap<Profile, ProfileDto>();
            CreateMap<Credential, CredentialDto>();
            CreateMap<CredentialDto, Credential>();
        }
    }
}
