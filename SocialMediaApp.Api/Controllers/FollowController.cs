using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using SocialMediaApp.Application.DTOs.Follows;
using SocialMediaApp.Application.Features.Follows.Request.Queries;
using SocialMediaApp.Application.Features.Follows.Request.Commands;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Features.Users.Request.Queries;
using Microsoft.AspNetCore.Authorization;

namespace SocialMediaApp.Api.Controllers
{
[Route("api/[controller]")]
[ApiController]
[Authorize]
    public class FollowController:ControllerBase
{
    private readonly IMediator _mediator;


    public FollowController(IMediator mediator)
    {
        _mediator = mediator;
        
    }

    // GET:follow
    [HttpGet]
    public async Task<ActionResult<List<FollowDto>>> Get()
    {
        var users = await _mediator.Send(new GetFollowsRequest());
        return users;
    }

    // GET: follow/folllowing/{id}
    [HttpGet("following/{FollowingId:Guid}")]
        //[HttpGet("following/{FollowingId:int}")]
        public async Task<ActionResult<List<FollowDto>>> GetFollowings(Guid FollowingId)
    {
        var follow = await _mediator.Send(new GetFollowingRequest {userId = FollowingId});
        
        return follow;
    }

    // POST: follow/followers
    [HttpGet("followers/{FollowerId:Guid}")]
   public async Task<ActionResult<List<FollowDto>>> GetFollowers(Guid FollowerId)
    {
        var follow = await _mediator.Send(new GetFollowerRequest {userId = FollowerId});
        
        return follow;
    }

   // POST: follow
    [HttpPost]
    public async Task<ActionResult> PostFollow([FromBody] CreateFollowDto  followDto)
        {
        var followcommand = new CreateFollowsRequest{createFollowDto = followDto};
        
        var followResponse = await _mediator.Send(followcommand);
        if (followResponse.Success == true)
        {
            var notificationDto = new CreateNotificationDto();
            var user = await _mediator.Send(new GetUserRequest { Id = followDto.FollowerId});

            notificationDto.UserId = followDto.FollowingId;
            notificationDto.Content = $"{user.Name} followed you recently";
            notificationDto.IsRead = false;

            var notificationCommand = new CreateNotificationRequest { CreateNotificationDto = notificationDto };
            await _mediator.Send(notificationCommand);
        }

            return Ok(followResponse);

    }
    // DELETE: follow/{id}
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        await _mediator.Send( new DeleteFollowCommandRequest{ Id = id });
        return NoContent();
    }
    }
}