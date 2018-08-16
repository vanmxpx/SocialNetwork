using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Json;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;


namespace SocialNetwork.Controllers
{
    //http://localhost:5000/api/authorizations/ - test url
    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthorizationsController : ControllerBase
    {
        private readonly IAuthorizationRepository repositoryAuthorization;
        private readonly ICredentialRepository repositoryCredential;
        private readonly IProfileRepository repositoryProfile;
        private readonly AppSettings appSettings;

        public AuthorizationsController(IAuthorizationRepository repositoryAuthorization,
                                         ICredentialRepository repositoryCredential,
                                         IProfileRepository repositoryProfile,
                                         IOptions<AppSettings> appSettings
                                         )
        {
            this.repositoryAuthorization = repositoryAuthorization;
            this.repositoryCredential = repositoryCredential;
            this.repositoryProfile = repositoryProfile;
            this.appSettings = appSettings.Value;
        }

        //http://localhost:5000/api/authorizations/{id} - test url
        [AllowAnonymous]//для теста
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Authorization))]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<ActionResult<Authorization>> GetAuthorizationById(int id)
        {
            //добавить валидацию id             
            var authorization = await repositoryAuthorization.GetById(id);
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
        public async Task<ActionResult<Profile>> AddAuthorization([FromBody]CredentialDto credentialDto)
        {
            Credential credential = repositoryCredential.Authenticate(credentialDto.Email, credentialDto.Password);
            if (credential == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, credential.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            Authorization authorization = new Authorization()
            {
                SystemStatus = "",
                Credential = await repositoryCredential.GetByEmail(credentialDto.Email)
            };
            await repositoryAuthorization.Create(authorization);

            // возвращаем основную информацию пользователя и токен для хранения клиентской части 
            Profile profile = await repositoryProfile.GetById(credential.ProfileRef);
            return Ok(new
            {
                Name = profile.Name,
                Login = profile.Login,
                LastName = profile.LastName,
                Age = profile.Age,
                Location = profile.Location,
                Photo = profile.Photo,
                Gender = profile.Gender,
                Token = tokenString
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(Authorization))]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id, Authorization authorization)
        {
            repositoryAuthorization.Update(id, authorization);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Authorization))]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<ActionResult<ICollection<Authorization>>> GetAllAuthorizationByCredential([FromQuery]int credentialId)
        {
            if (credentialId != 0)
            {
                var authorizations = await repositoryAuthorization.GetAllAuthorizantionsByCredentialId(credentialId);
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