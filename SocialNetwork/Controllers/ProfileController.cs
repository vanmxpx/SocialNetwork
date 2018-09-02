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
            if (profile != null)
            {
                return new OkObjectResult(profile);
            }
            return NotFound();
        }

        //http://localhost:5000/api/profiles/login/?{login}
        [AllowAnonymous]
        [HttpGet]
        [Route("login")]
        [ProducesResponseType(200, Type = typeof(ProfileDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProfileDto>> GetProfileByLogin([FromQuery]string login)
        {
            var profile = await unitOfWork.ProfileRepository.GetByLogin(login);
            if (profile != null)
            {
                var profileDto = mapper.Map<ProfileDto>(profile);
                return new OkObjectResult(profileDto);
            }
            return NotFound();
        }

        //http://localhost:5000/api/profiles/name/?{name}&{lastName}
        [AllowAnonymous]
        [HttpGet]
        [Route("name")]
        [ProducesResponseType(200, Type = typeof(ProfileDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<ProfileDto>>> GetProfileByNameAndLastName([FromQuery]string name, [FromQuery]string lastName)
        {
            List<Profile> profiles = await unitOfWork.ProfileRepository.GetByNameAndLastName(name, lastName);
            List<ProfileDto> profileDTOs;
            if(profiles != null)
            {
                profileDTOs = new List<ProfileDto>(profiles.Count);
                for (int i = 0; i < profiles.Count; i++)
                {
                    profileDTOs.Add(mapper.Map<ProfileDto>(profiles[i]));
                }
                return new OkObjectResult(profileDTOs);
            }
            return NotFound();
        }

        // DELETE api/profiles/50
        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await unitOfWork.ProfileRepository.GetById(id);
            if (entity != null)
            {
                unitOfWork.ProfileRepository.Delete(entity);
                await unitOfWork.Save();
                return Ok();
            }
            return NotFound();
        }
    }
}