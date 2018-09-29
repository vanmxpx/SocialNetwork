using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SocialNetwork.Services;
using SocialNetwork.Repositories;
using SocialNetwork.Configurations;
using AutoMapper;

namespace SocialNetwork.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfigProvider provider;
        private readonly IMapper mapper;
        public RegistrationController(IUnitOfWork unitOfWork, IConfigProvider provider, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.provider = provider;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> GetCredential(CredentialDto c)
        {
            if (c.Email == null)
                return Ok("Email is null");
            if (c.Login == null)
                return Ok("Login is null");
            if (c.Password == null)
                return Ok("Password is null");

            Credential cred = mapper.Map<CredentialDto, Credential>(c);
            Profile p = new Profile();
            p.Login = c.Login;

            if (await unitOfWork.CredentialRepository.GetByEmail(cred.Email) != null)
                return Ok("the email already exists");
            if (await unitOfWork.ProfileRepository.GetByLogin(p.Login) != null)
                return Ok("the login already exists");

            EmailSender emailService = new MailKitSender(provider.STMPConnection);
            int timeout = provider.STMPConnection.TimeOut;
            var task = emailService.SendConfirmEmailAsync(cred.Email, cred.Password);
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                if (task.IsFaulted)
                    return Ok("TimeOut");

                await unitOfWork.ProfileRepository.Create(p);
                cred.Profile = p;


                await unitOfWork.CredentialRepository.Create(cred);
                await unitOfWork.Save();

                return Ok("Ok");

            }

            return Ok();
        }


        [HttpGet("{email}/{hash}")]
        public async Task<IActionResult> ConfirmEmail(string email, string hash)
        {
            Credential cred = await unitOfWork.CredentialRepository.GetByEmail(email);
            if (cred != null)
            {
                if (hash == Sha256Service.Convert(cred.Email + cred.Password))
                {
                    cred.DateRegistration = DateTime.Now;
                    unitOfWork.CredentialRepository.Update(cred.Id, cred);
                    await unitOfWork.Save();
                    return RedirectPermanent("http://localhost:5000/login/" + email + "/" + cred.Password);
                }
                else
                    return BadRequest("Broken link");
            }
            else
                return BadRequest("link is outdated");
        }

    }
}