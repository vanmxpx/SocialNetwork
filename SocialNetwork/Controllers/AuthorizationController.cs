using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Json;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Text;


namespace SocialNetwork.Controllers
{
    //http://localhost:5000/api/authorizations/ - test url
    [Authorize]
    [ApiController]
    [Route("/api/login")]
    public class AuthorizationsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AppSettings appSettings;
        public AuthorizationsController(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            this.unitOfWork = unitOfWork;
            this.appSettings = appSettings.Value;
        }

        //http://localhost:5000/api/authorizations/{id} - test url
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Authorization))]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<ActionResult<Authorization>> GetAuthorizationById(int id)
        {
            //добавить валидацию id             
            var authorization = await unitOfWork.AuthorizationRepository.GetById(id);
            if (authorization != null)
            {
                return Ok(authorization);
            }
            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Authorization))]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<ActionResult<Authorization>> AddAuthorization([FromBody]CredentialDto credentialDto)
        {
            Credential credential = unitOfWork.CredentialRepository.Authenticate(credentialDto.Email, credentialDto.Password);
            if (credential == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            Authorization authorization = new Authorization()
            {
                SystemStatus = "",
                DatetimeStart = DateTime.Now,
                Credential = await unitOfWork.CredentialRepository.GetByEmail(credentialDto.Email)
            };

            await unitOfWork.AuthorizationRepository.Create(authorization);

            return Ok(new { Token = new TokenFactory(appSettings, credential).GetStringToken() });
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(Authorization))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var authorization = await unitOfWork.AuthorizationRepository.GetById(id);
            if (authorization != null)
            {
                await unitOfWork.AuthorizationRepository.Delete(authorization);
                return Ok();
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Authorization))]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<ActionResult<ICollection<Authorization>>> GetAllAuthorizationByCredential([FromQuery]int credentialId)
        {
            if (credentialId != 0)
            {
                var authorizations = await unitOfWork.AuthorizationRepository.GetAllAuthorizantionsByCredentialId(credentialId);
                if (authorizations != null)
                {
                    return new OkObjectResult(authorizations);
                }
                return NotFound();
            }
            return NotFound();
        }
    }
}