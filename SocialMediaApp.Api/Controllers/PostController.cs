﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.Features.Comments.Request.Queries;
using SocialMediaApp.Application.Features.Follows.Request.Queries;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Features.Users.Request.Queries;
using SocialMediaApp.Domain;
using System.Xml.Linq;

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
        [HttpGet("{UserId:Guid}")]
        public async Task<ActionResult<List<PostDto>>> Get(Guid UserId)
        {
            var posts = await _mediator.Send(new GetPostsRequestByUser { UserId = UserId});

            return Ok(posts);
        }

        // GET api/<PostController>/5
        [HttpGet("{UserId:Guid},{id:Guid}")]
        public async Task<ActionResult<PostDto>> Get(Guid UserId, Guid id)
        {
            var post = await _mediator.Send(new GetPostRequestById{Id=id, UserID = UserId});
            if(post != null)
            {
                post.Comments = await _mediator.Send(new GetCommentListRequest { Id = id });
            }
            return Ok(post);
        }  

        // POST api/<PostController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePostDto post)
        {
            var command = new CreatePostsCommand { postDto = post };
            var response = await _mediator.Send(command);
            if(response.Success == true)
            {
                var followers = await _mediator.Send(new GetFollowerRequest { userId = post.UserId });
                var user = await _mediator.Send(new GetUserRequest { Id = post.UserId });
                var notificationDto = new CreateNotificationDto();

                notificationDto.IsRead = false;
                notificationDto.Content = $"{user.Name} posted {post.Title}";
                foreach (var follower in followers)
                {
                    notificationDto.UserId = follower.CurrentUser;
                    var notificationCommand = new CreateNotificationRequest { CreateNotificationDto = notificationDto };
                    await _mediator.Send(notificationCommand);
                }

            }
            return Ok(response);
        }

        // PUT api/<PostController>/5
        [HttpPut]
        public async Task<ActionResult>  UpdatePost([FromBody] UpdatePostDto posts)
        {
            var command = new UpdatePostsCommand {post = posts };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<PostController>/5 
        [HttpDelete("{id:Guid}, {UserId:Guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid UserId)
        {
            await _mediator.Send(new DeletePostCommand { Id  =id, UserId = UserId});
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<PostDto>>> SearchPosts(string q)
        {
            var posts = await _mediator.Send(new SearchPostRequest{query = q});

            return posts;
        }
    }
}
