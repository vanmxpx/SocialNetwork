using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Controllers
{
    //http://localhost:5000/api/profiles/{id} - test url
    [Route("/api/[controller]")]
    public class ProfilesController : Controller
    {
        private readonly IProfileRepository repository;

        public ProfilesController(IProfileRepository repository)
        {
            this.repository = repository;
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