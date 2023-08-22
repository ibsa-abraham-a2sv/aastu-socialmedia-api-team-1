using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.Features.Posts.Request.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        // GET: api/<PostController>
        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> Get()
        {
            var posts = await _mediator.Send(new GetPostsRequest());

            return Ok(posts);
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> Get(int id)
        {
            var post = await _mediator.Send(new GetPostRequestById{Id=id});
            return Ok(post);
        }  

        // POST api/<PostController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePostDto post)
        {
            var command = new CreatePostsCommand { postDto = post };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult>  UpdatePost(int id, [FromBody] UpdatePostDto posts)
        {
            var command = new UpdatePostsCommand {Id = id, post = posts };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<PostController>/5 
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeletePostCommand { Id  =id});
            return NoContent();
        }
    }
}
