using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.Hosting;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Features.Comments.Request.Commands;
using SocialMediaApp.Application.Features.Comments.Request.Queries;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Features.Notifications.Request.Queries;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Features.Users.Request.Queries;
using SocialMediaApp.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public IMediator _mediator { get; }

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<CommentController>
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<List<CommentDto>>> Get(int userId)
        {
            var query = new GetCommentListRequest { Id = userId };
            var comments = await _mediator.Send(query);
            return Ok(comments);
        }

        // GET api/<CommentController>/5
        [HttpGet("/GetComment/{id:int}")]
        public async Task<ActionResult<CommentDto>> GetComment( int id)
        {
            var query = new GetCommentDetailRequest { Id = id };
            var comment = await _mediator.Send(query);
            return Ok(comment);
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCommentDto commentDto)
        {
            var command = new CreateCommentRequest { creatCommentDto = commentDto };
            var response = await _mediator.Send(command);
            if (response.Success == true)
            {
                var notificationDto = new CreateNotificationDto();
                var user = await _mediator.Send(new GetUserRequest { Id = commentDto.UserId});
                var post = await _mediator.Send(new GetPostRequestById { Id = commentDto.PostId, UserID = user.Id });

                notificationDto.UserId = user.Id;
                notificationDto.Content = $"{user.Name} commented on your {post.Title} post";
                notificationDto.IsRead = false;

                var notificationCommand = new CreateNotificationRequest { CreateNotificationDto = notificationDto };
                await _mediator.Send(notificationCommand);
            }
            return Ok(response);
        }

        // PUT api/<CommentController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateCommentDto updateCommentDto)
        {
            var command = new UpdateCommentRequest { updatedCommentDto = updateCommentDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{userId:int},{id:int}")]
        public async Task<ActionResult<int>> Delete(int userId, int id)
        {
            var command = new DeleteCommentRequest { UserId= userId, Id = id};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
