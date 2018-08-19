using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using SocialNetwork.Services;
using System;
using Microsoft.AspNetCore.Authorization;


namespace SocialNetwork.Controllers
{
    [Authorize]
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

        [HttpPost("{email}/{Login}/{password}")]
        public async Task<ActionResult> Register(string email, string login, string password)
        {

            Credential cred = await unitOfWork.CredentialRepository.GetByEmail(email);
            Profile prof = await unitOfWork.ProfileRepository.GetByLogin(login);

            EmailSender emailService = new EmailSender();
            if (cred == null && prof == null)
            {
                await emailService.SendEmailAsync(email, "Confirm email", "http://localhost:5000/api/credential/" + email + "\\" + Sha256Service.Convert(email + password));

                prof = new Profile()
                {
                    
                    Login = login
                };
                cred = new Credential()
                {
                    Email = email,
                    Password = password,
                    Profile = prof
                };
                
               await unitOfWork.ProfileRepository.Create(prof);
               await unitOfWork.CredentialRepository.Create(cred);
                await unitOfWork.Save();

                return Ok("Ok");
            }
            else
            {
                return Ok("Email already exist");
            }
        }
        [HttpPost("{email}/{hash}")]
        public async Task<ActionResult> ConfirmEmail(string email, string hash)
        {
            Credential cred = await unitOfWork.CredentialRepository.GetByEmail(email);
            if (cred != null)
            {
                if (hash == Sha256Service.Convert(cred.Email + cred.Password))
                    return Ok("Yeah it's work");
                else
                    return Ok("Broken link");
            }
            else
                return Ok("link is outdated");
        }



    }
}