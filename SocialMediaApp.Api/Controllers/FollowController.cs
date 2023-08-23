using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using SocialMediaApp.Application.DTOs.Follows;
using SocialMediaApp.Application.Features.Follows.Request.Queries;
using SocialMediaApp.Application.Features.Follows.Request.Commands;

namespace SocialMediaApp.Api.Controllers
{
[Route("api/[controller]")]
[ApiController]
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
    [HttpGet("following/{FollowingId:int}")]
        //[HttpGet("following/{FollowingId:int}")]
        public async Task<ActionResult<List<FollowDto>>> GetFollowings(int FollowingId)
    {
        var follow = await _mediator.Send(new GetFollowingRequest {userId = FollowingId});
        
        return follow;
    }

    // POST: follow/followers
    [HttpGet("followers/{FollowerId:int}")]
   public async Task<ActionResult<List<FollowDto>>> GetFollowers(int FollowerId)
    {
        var follow = await _mediator.Send(new GetFollowerRequest {userId = FollowerId});
        
        return follow;
    }

   // POST: follow
    [HttpPost]
    public async Task<ActionResult> PostFollow([FromBody] FollowDto  followDto)
    {
        var followcommand = new CreateFollowsRequest{createFollowDto = followDto};
        
        var followRespond = await _mediator.Send(followcommand);

        return Ok(followRespond);

    }
    // DELETE: follow/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        await _mediator.Send( new DeleteFollowCommandRequest{ Id = id });
        return NoContent();
    }
    }
}