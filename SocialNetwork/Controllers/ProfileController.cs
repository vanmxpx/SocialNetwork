using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using AutoMapper;
using System.IO;
using Microsoft.AspNetCore.Http;

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

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetProfilesByNameOrLastName([FromQuery]string name, [FromQuery] string lastName, [FromQuery] int from, [FromQuery] int count)
        {

            return Ok();
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("{login}/{from}/{count}")]
        public async Task<IActionResult> GetProfilesByLogin(string login, int from, int count)
        {
            if (from >= 0 && count > 0)
            {
                return new OkObjectResult(unitOfWork.ProfileRepository.GetCoincidentallyLogin(login, from, count));
            }
            else
            {
                return BadRequest();
            }


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
            if (profiles != null)
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
            var profile = await unitOfWork.ProfileRepository.GetById(id);

            if (User.Identity.Name != profile.Id.ToString())
            {
                return Unauthorized();
            }

            var credential = await unitOfWork.CredentialRepository.GetById(id);

            if (profile != null)
            {
                unitOfWork.ProfileRepository.Delete(profile);
                unitOfWork.CredentialRepository.Delete(credential);
                await unitOfWork.Save();
                return Ok();
            }
            return NotFound();
        }

        // [HttpPost]
        // [Route("avatar")]
        // public async Task<IActionResult> UploadImage()
        // {
        //     var file = Request.Form.Files[0];
        //     if (file == null || file.Length == 0)
        //         return Content("file not selected");

        //     //TODO: check on file format (.jpg)

        //     var path = Path.Combine(
        //                 Directory.GetCurrentDirectory(), "client/src/assets/avatars/avatar",
        //                 User.Identity.Name + ".jpg");

        //     using (var stream = new FileStream(path, FileMode.Create))
        //     {
        //         await file.CopyToAsync(stream);
        //     }
        //     Profile profile = await unitOfWork.ProfileRepository.GetById(int.Parse(User.Identity.Name));
        //     profile.PhotoUrl = "/assets/avatars/avatar" +
        //                 profile.Id + ".jpg";

        //     return Ok();
        // }
        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult> UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file == null || file.Length == 0)
                    return Content("file not selected");

                //TODO: check on file format (.jpg)

                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "client/src/assets/avatars",
                            User.Identity.Name + ".png");

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                Profile profile = await unitOfWork.ProfileRepository.GetById(int.Parse(User.Identity.Name));
                profile.PhotoUrl = "./assets/avatars/" +
                            profile.Id + ".png";
                unitOfWork.ProfileRepository.Update(profile);
                await unitOfWork.Save();

                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest("Upload Failed: " + ex.Message);
            }
        }
    }
}