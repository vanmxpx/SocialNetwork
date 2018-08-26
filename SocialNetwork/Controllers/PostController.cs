using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public PostsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET api/posts/79
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Post))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = await unitOfWork.PostRepository.GetById(id);
            if (post != null)
            {
                return new OkObjectResult(post);
            }
            return NotFound();
        }

        // GET api/posts/?authorId=2
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Post>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ICollection<Post>>> GetAllPostByAuthor([FromQuery]int authorId)
        {
            if (authorId != 0)
            {
                var posts = await unitOfWork.PostRepository.GetByAuthorId(authorId);
                if (posts != null)
                {
                    return new OkObjectResult(posts);
                }
                return NotFound();
            }
            return NotFound();
        }

        // POST api/posts
        [HttpPost]
        public async Task<ActionResult> AddPost([FromBody]Post post)
        {
            if (!ModelState.IsValid) return BadRequest();
            await unitOfWork.PostRepository.Create(post);
            return Created("api/post", post);
        }

        // DELETE api/posts/100
        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await unitOfWork.PostRepository.GetById(id);
            if (entity != null)
            {
                unitOfWork.PostRepository.Delete(entity);
                await unitOfWork.Save();
                return Ok();
            }
            return NotFound();
        }
    }
}