using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Application.DTOs.Likes;
using SocialMediaApp.Application.Features.Likes.Request.Commands;
using SocialMediaApp.Application.Features.Likes.Request.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        public readonly IMediator _mediator;

        public LikeController(IMediator mediator)
        {
            _mediator = mediator;
            
        }
        

        // GET api/<LikeController>/5
        [HttpGet("{PostId}")]
        public async Task<ActionResult<List<LikeDto>>> Get(int PostId)
        {
            var likes = await _mediator.Send(new GetLikesRequest { PostId = PostId });

            return Ok(likes);
        }

        // POST api/<LikeController>
        [HttpPost]
        public async void Post([FromBody] CreateLikeDto likeDto)
        {
            var command = new CreateLikeRequest { LikeDto = likeDto };
            await _mediator.Send(command);

        }
       

        // DELETE api/<LikeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Unlike(int id)
        {
            await _mediator.Send(new DeleteLikeRequest { LikeId = id });
            return NoContent();
        }
    }
}
