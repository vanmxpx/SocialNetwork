using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using AutoMapper;

namespace SocialNetwork.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class FollowingsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FollowingsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET api/followings/bloggers/?id=24
        [AllowAnonymous]
        [Route("bloggers")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Post>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ICollection<Profile>>> GetBloggersByProfileId([FromQuery]int id)
        {
            if (id != 0)
            {
                List<Followings> followings = await unitOfWork.FollowingsRepository.GetBlogersById(id);
                List<Profile> bloggers = new List<Profile>();
                if (followings != null)
                {
                    foreach (Followings following in followings)
                    {
                        bloggers.Add(await unitOfWork.ProfileRepository.GetById(following.BloggerRef));
                    }
                    return new OkObjectResult(bloggers);
                }
                return NotFound();
            }
            return NotFound();
        }

        // GET api/followings/subscribers/?id=24
        [AllowAnonymous]
        [Route("subscribers")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Post>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ICollection<Profile>>> GetSubscribersByProfileId([FromQuery]int id)
        {
            if (id != 0)
            {
                List<Followings> followings = await unitOfWork.FollowingsRepository.GetSuscribersById(id);
                List<Profile> subscribers = new List<Profile>();
                if (followings != null)
                {
                    foreach (Followings following in followings)
                    {
                        subscribers.Add(await unitOfWork.ProfileRepository.GetById(following.SubscriberRef));
                    }
                    return new OkObjectResult(subscribers);
                }
                return NotFound();
            }
            return NotFound();
        }

        // POST api/followings
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> AddRelationship([FromBody]Followings following)
        {
            if (!ModelState.IsValid) return BadRequest();
            await unitOfWork.FollowingsRepository.Create(following);
            return Created("api/followers", following);
        }
    }
}