using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using Microsoft.AspNetCore.Authorization;


namespace SocialNetwork.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class CredentialController : Controller
    {
        private readonly ICredentialRepository CredentialRepository;

        public CredentialController(ICredentialRepository repositoryCredential)
        {
            this.CredentialRepository = repositoryCredential;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult> GetByEmail(string email)
        {
            var Credential = await CredentialRepository.GetByEmail(email);
            if(Credential==null)
            return NotFound();
            else
            return new OkObjectResult(Json(Credential));
        }





    }
}