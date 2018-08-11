using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Controllers
{
    //http://localhost:5000/api/post/{id} - test url
    [Route("/api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostRepository repository;

        public PostController(IPostRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Post))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = await repository.GetById(id);
            if(post != null)
            {
                return new OkObjectResult(Json(post));
            }
            return NotFound();
        }
    }
}