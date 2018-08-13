using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Controllers
{
    //http://localhost:5000/api/authorizations/ - test url
    [Route("/api/[controller]")]
    public class AuthorizationsController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public AuthorizationsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //http://localhost:5000/api/authorizations/{id} - test url
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Authorization))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Authorization>> GetAuthorizationById(int id)
        {
            //добавить валидацию id             
            var authorization = await unitOfWork.AuthorizationRepository.GetById(id);
            if (authorization != null)
            {
                return new OkObjectResult(Json(authorization));
            }
            return NotFound();
        }

        
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Authorization))]
        [ProducesResponseType(404)]
        public async void AddAuthorization([FromBody]string email, [FromBody]string password)
        {
            // FIXME: добавить валидацию данных
            // JWT, OAuth, JSession

            Authorization authorization = new Authorization()
            {
                // FIXME: определить статусы
                SystemStatus = "",
                Credential = await unitOfWork.CredentialRepository.GetByEmail(email)  //??              
            };
            await unitOfWork.AuthorizationRepository.Create(authorization);
        }
    }
}