using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using SocialNetwork.Services;

namespace SocialNetwork.Controllers
{
    [Route("/api/[controller]")]
    public class CredentialController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CredentialController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult> GetByEmail(string email)
        {
            var Credential = await unitOfWork.CredentialRepository.GetByEmail(email);
            if (Credential == null)
                return NotFound();
            else
                return new OkObjectResult(Json(Credential));
        }

        [HttpPost("{email}")]
        public async Task<ActionResult> Register(string email)
        {
            
            EmailSender emailService = new EmailSender();
            await emailService.SendEmailAsync(email, "Confirm email", "Hello world");
            return Ok();
        }





    }
}