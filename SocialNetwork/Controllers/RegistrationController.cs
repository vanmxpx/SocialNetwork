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

            Credential CredentialDb = await unitOfWork.CredentialRepository.GetByEmail(cred.Email);
            Profile ProfileDb = await unitOfWork.ProfileRepository.GetByLogin(p.Login);

            if (ProfileDb != null) // Сложная конструкция проверки на ошибку -_-
                if (CredentialDb != null)
                {
                    if (CredentialDb.DateRegistration != DateTime.MinValue)
                        return Ok("User already exist");
                }
                else
                    return Ok("Login already exist");
            else
                if (CredentialDb != null)
                if (CredentialDb.DateRegistration != DateTime.MinValue)
                    return Ok("Email already exist");


            EmailSender emailService = new MailKitSender(provider.STMPConnection);
            int timeout = provider.STMPConnection.TimeOut;
            var task = emailService.SendConfirmEmailAsync(cred.Email, cred.Password);
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                if (task.IsFaulted)
                    return Ok("TimeOut");


                if (CredentialDb != null)
                    unitOfWork.CredentialRepository.Delete(CredentialDb);
                if (ProfileDb != null)
                    unitOfWork.ProfileRepository.Delete(ProfileDb);
                    
                cred.Profile = p;
                p.CredenitialRef = cred.Id;

                await unitOfWork.ProfileRepository.Create(p);
                await unitOfWork.CredentialRepository.Create(cred);
                await unitOfWork.Save();

                return Ok("Email send to " + cred.Email);

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