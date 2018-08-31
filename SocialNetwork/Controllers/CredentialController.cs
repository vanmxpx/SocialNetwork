using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using SocialNetwork.Services;
using SocialNetwork.Configurations;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;


namespace SocialNetwork.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class CredentialController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfigProvider provider;

        public CredentialController(IUnitOfWork unitOfWork, IConfigProvider provider)
        {
            this.unitOfWork = unitOfWork;
            this.provider = provider;
        }

        [AllowAnonymous]
        [HttpGet("{email}")]
        public async Task<ActionResult> GetByEmail(string email)
        {
            var Credential = await unitOfWork.CredentialRepository.GetByEmail(email);
            if (Credential == null)
                return NotFound();
            else
                return new OkObjectResult(Json(Credential));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> TestVoid()
        {
            string altitudeString = Request.Form.FirstOrDefault(p => p.Key == "email").Value;
            int altitude = Int32.Parse(altitudeString);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("{email}/{login}/{password}/{name}/{lastName}")]
        public async Task<IActionResult> Register(string email, string login, string password, string name = null, string lastName = null)
        {

            Credential cred = await unitOfWork.CredentialRepository.GetByEmail(email);
            Profile prof = await unitOfWork.ProfileRepository.GetByLogin(login);
            EmailSender emailService = new MailKitSender(provider.STMPConnection);

            if (cred != null)
                return Ok("The Email already exist");
            if (prof != null)
                return Ok("The Login already exist");

            int timeout = provider.STMPConnection.TimeOut;
            var task = emailService.SendConfirmEmailAsync(email, password);
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                if (task.IsFaulted)
                    return Ok("Incorrect email");

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
                return Ok("TimeOut");
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
                    await unitOfWork.CredentialRepository.Update(cred.Id, cred);
                    await unitOfWork.Save();
                    return Ok("Yeah it's work");
                }
                else
                    return Ok("Broken link");
            }
            else
                return Ok("link is outdated");
        }



    }
}