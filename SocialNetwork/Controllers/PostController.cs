using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using AutoMapper;
using System;

namespace SocialNetwork.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PostsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET api/posts/79
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Post))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PostDto>> GetPostById(int id)
        {
            var post = await unitOfWork.PostRepository.GetById(id);
            if (post != null)
            {
                var postDto = mapper.Map<Post, PostDto>(post);
                return new OkObjectResult(postDto);
            }
            return NotFound();
        }

        // GET api/posts/?authorId=2
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Post>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ICollection<PostDto>>> GetAllPostByAuthor([FromQuery]int authorId)
        {
            if (authorId != 0)
            {
                var posts = await unitOfWork.PostRepository.GetByAuthorId(authorId);
                if (posts != null)
                {
                    return new OkObjectResult(mapper.Map<List<Post>, List<PostDto>>(
                        posts
                    .OrderByDescending(p => p.Datetime)
                    .ToList()));
                }
                return NotFound();
            }
            return NotFound();
        }


        // GET api/posts/news/?id=2
        [HttpGet]
        [Route("news")]
        [ProducesResponseType(200, Type = typeof(ICollection<Post>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ICollection<PostDto>>> GetNewsById([FromQuery]int id)
        {
            if (id != 0)
            {
                List<Post> posts = await unitOfWork.PostRepository.GetNewsById(id);
                if (posts.Count > 0)
                {
                    return new OkObjectResult(mapper.Map<List<Post>, List<PostDto>>(posts));
                }
                return NotFound();
            }
            return NotFound();
        }

        // POST api/posts
        [HttpPost]
        public async Task<ActionResult> AddPost([FromBody]Post post)
        {
            post.Datetime = DateTime.Now;
            if (post.Text.Length < 256
            && post.Text.Length > 0
            && post.ProfileRef != 0)
            {
                if (!ModelState.IsValid) return BadRequest();
                await unitOfWork.PostRepository.Create(post);
                await unitOfWork.Save();
                return Created("api/post", post);
            }
            return BadRequest();
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