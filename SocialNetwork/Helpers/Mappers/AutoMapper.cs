using AutoMapper;
using SocialNetwork.Models;

namespace SocialNetwork
{
    public class AutoMapperPost : AutoMapper.Profile
    {
        public AutoMapperPost()
        {
            CreateMap<Post, PostDto>();
            CreateMap<SocialNetwork.Models.Profile, ProfileDto>();
        }
    }
}
