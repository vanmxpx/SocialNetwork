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
    public class CredentialsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfigProvider provider;

        public CredentialsController(IUnitOfWork unitOfWork, IConfigProvider provider)
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

        [AllowAnonymous]
        [HttpPost("{email}/{Login}/{password}/{name}/{lastName}")]
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
            var task = emailService.SendConfirmEmailAsync(email,password);
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
                    unitOfWork.CredentialRepository.Update(cred.Id, cred);
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