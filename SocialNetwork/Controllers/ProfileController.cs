using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using AutoMapper;

namespace SocialNetwork.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProfilesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        //http://localhost:5000/api/profiles/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Profile))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Profile>> GetProfileById(int id)
        {
            var profile = await unitOfWork.ProfileRepository.GetById(id);
            if(profile != null)
            {
                return new OkObjectResult(profile);
            }
            return NotFound();
        }

        //http://localhost:5000/api/profiles/login/?{login}
        [HttpGet]
        [Route("login")]
        [ProducesResponseType(200, Type = typeof(Profile))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Profile>> GetProfileByLogin([FromQuery]string login)
        {
            var profile = await unitOfWork.ProfileRepository.GetByLogin(login);
            if(profile != null)
            {
                var profileDto = mapper.Map<ProfileDto>(profile);
                return new OkObjectResult(profileDto);
            }
            return NotFound();
        }

        //http://localhost:5000/api/profiles/name/?{name}&{lastName}
        [HttpGet]
        [Route("name")]
        [ProducesResponseType(200, Type = typeof(Profile))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Profile>> GetProfileByNameAndLastName([FromQuery]string name, [FromQuery]string lastName)
        {
            var profile = await unitOfWork.ProfileRepository.GetByNameAndLastName(name, lastName);
            if(profile != null)
            {
                return new OkObjectResult(profile);
            }
            return NotFound();
        }
    }
}