using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using SocialNetwork.Services;
using SocialNetwork.Configurations;
using System;
using Microsoft.AspNetCore.Authorization;


namespace SocialNetwork.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class CredentialsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfigProvider provider;

        public CredentialsController(IUnitOfWork unitOfWork, IConfigProvider provider)
        {
            this.unitOfWork = unitOfWork;
            this.provider = provider;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult> GetByEmail(string email)
        {
            var credential = await unitOfWork.CredentialRepository.GetByEmail(email);
            if (credential != null)
            {
                if (User.Identity.Name != credential.Id.ToString())
                {
                    return Unauthorized();
                }
                return new OkObjectResult(credential);
            }
            else
            {
                return NotFound();
            }
        }

        [AllowAnonymous]
        [HttpPost]//("{email}/{Login}/{password}/{name}/{lastName}")
        public async Task<IActionResult> Register(string email, string login, string password, string name = null, string lastName = null)
        {
            Credential cred = await unitOfWork.CredentialRepository.GetByEmail(email);
            Profile prof = await unitOfWork.ProfileRepository.GetByLogin(login);
            EmailSender emailService = new MailKitSender(provider.STMPConnection);

            if (cred != null)
                return BadRequest("The Email already exist");
            if (prof != null)
                return BadRequest("The Login already exist");

            int timeout = provider.STMPConnection.TimeOut;
            var task = emailService.SendConfirmEmailAsync(email, password);
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                if (task.IsFaulted)
                    return BadRequest("Incorrect email");

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

                if (name != null)
                    prof.Name = name;
                if (lastName != null)
                    prof.LastName = name;

                await unitOfWork.ProfileRepository.Create(prof);
                await unitOfWork.CredentialRepository.Create(cred);
                await unitOfWork.Save();

                return Ok("Ok");

            }
            else
            {
                return BadRequest("TimeOut");
            }
        }


        [AllowAnonymous]
        [HttpPost("{email}/{hash}")]
        public async Task<ActionResult> ConfirmEmail(string email, string hash)
        {
            Credential cred = await unitOfWork.CredentialRepository.GetByEmail(email);
            if (cred != null)
            {
                if (hash == Sha256Service.Convert(cred.Email + cred.Password))
                {
                    cred.DateRegistration = DateTime.Now;
                    unitOfWork.CredentialRepository.Update(cred.Id, cred);
                    await unitOfWork.Save();
                    return Ok("Yeah it's work");
                }
                else
                    return BadRequest("Broken link");
            }
            else
                return BadRequest("link is outdated");
        }
    }
}