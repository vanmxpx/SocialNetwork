using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Controllers
{
    [Route("/api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostRepository repository;

        public PostsController(IPostRepository repository)
        {
            this.repository = repository;
        }

        // GET api/posts/79
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Post))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = await repository.GetById(id);
            if (post != null)
            {
                return new OkObjectResult(Json(post));
            }
            return NotFound();
        }

        // GET api/posts/?authorId=2
        [HttpGet]
        public async Task<ActionResult<ICollection<Post>>> GetAllPostByAuthor([FromQuery]int authorId)
        {
            if (authorId != 0)
            {
                var posts = await repository.GetByAuthorId(authorId);
                if (posts != null)
                {
                    return new OkObjectResult(Json(posts));
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
            await repository.CreatePost(post);
            return Created("api/post", post);
        }

        // DELETE api/posts/100
        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await repository.GetById(id);
            if (entity != null)
            {
                await repository.Delete(entity);
                return Ok();
            }
            return NotFound();
        }
    }
}