using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Likes;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Features.Likes.Request.Commands;
using SocialMediaApp.Application.Features.Likes.Request.Queries;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Features.Users.Request.Queries;

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
        [HttpGet("{PostId:Guid}")]
        public async Task<ActionResult<List<LikeDto>>> Get(Guid PostId)
        {
            var likes = await _mediator.Send(new GetLikesRequest { PostId = PostId });

            return Ok(likes);
        }

        // POST api/<LikeController>
        [HttpPost]
        public async Task<ActionResult<LikeDto>> Post([FromBody] CreateLikeDto likeDto)
        {

            var command = new CreateLikeRequest { LikeDto = likeDto };
            var response = await _mediator.Send(command);
            if(response.Success == true)
            {
                var notificationDto = new CreateNotificationDto();
                var user = await _mediator.Send(new GetUserRequest { Id = likeDto.UserId });
                var post = await _mediator.Send(new GetPostRequestById { Id = likeDto.PostId, UserID = user.Id });

                notificationDto.UserId = post.UserId;
                notificationDto.Content = $"{user.Name} liked your {post.Title} post";
                notificationDto.IsRead = false;

                var notificationCommand = new CreateNotificationRequest { CreateNotificationDto = notificationDto };
                await _mediator.Send(notificationCommand);
            }

            return Ok(response);

        }
       

        // DELETE api/<LikeController>/5
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Unlike(Guid id)
        {
            await _mediator.Send(new DeleteLikeRequest { LikeId = id });
            return NoContent();
        }
    }
}
