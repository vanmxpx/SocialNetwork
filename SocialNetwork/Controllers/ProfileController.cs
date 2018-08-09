using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Controllers
{
    //http://localhost:5000/api/profile/{id} - test url
    [Route("/api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly ProfileRepository repository;

        public ProfileController(IProfileRepository repository)
        {
            this.repository = (ProfileRepository)repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Profile))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Profile>> GetProfileById(int id)
        {
            var profile = await repository.GetById(id);
            if(profile != null)
            {
                return new OkObjectResult(Json(profile));
            }
            return NotFound();
        }


    }
}