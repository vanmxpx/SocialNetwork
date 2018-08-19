using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Controllers
{
    [Route("/api/[controller]")]
    public class CredentialsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CredentialsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult> GetByEmail(string email)
        {
            var Credential = await unitOfWork.CredentialRepository.GetByEmail(email);
            if(Credential==null)
            return NotFound();
            else
            return new OkObjectResult(Json(Credential));
        }

        // DELETE api/credentials/50
        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
           var entity = await unitOfWork.CredentialRepository.GetById(id);
           //var profile = await unitOfWork.ProfileRepository.GetById(id);
            if (entity != null)
            {
                //entity.Profile = profile;
                unitOfWork.CredentialRepository.Delete(entity);
                await unitOfWork.Save();
                return Ok();
            }
            return NotFound();
        }
    }
}