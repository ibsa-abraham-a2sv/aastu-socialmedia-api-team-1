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
public class FollowController:ControllerBase
{
    private readonly IMediator _mediator;


    public FollowController(IMediator mediator)
    {
        _mediator = mediator;
        
    }

    // GET: api/items
    [HttpGet]
    public async Task<ActionResult<List<FollowDto>>> Get()
    {
        var users = await _mediator.Send(new GetFollowsRequest());
        return users;
    }

    // GET: api/items/{id}
    [HttpGet("following/{Followingid:int},{id:int}")]
    public async Task<ActionResult<List<FollowDto>>> GetFollowings(int FollowingId, int id)
    {
        var follow = await _mediator.Send(new GetFollowerRequest {userId = FollowingId,Id = id});
        
        return follow;
    }

    // POST: api/items
    [HttpGet("followers/{FollowerId},{id:int}")]
   public async Task<ActionResult<List<FollowDto>>> GetFollowers(int FollowerId, int id)
    {
        var follow = await _mediator.Send(new GetFollowerRequest {userId = FollowerId,Id = id});
        
        return follow;
    }

   // POST: api/items
    [HttpPost]
    public async Task<ActionResult> PostFollow([FromBody] FollowDto  followDto)
    {
        var followcommand = new CreateFollowsRequest{createFollowDto = followDto};
        
        var followRespond = await _mediator.Send(followcommand);

        return Ok(followRespond);

    }
    // DELETE: api/items/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        await _mediator.Send( new DeleteFollowCommandRequest{ Id = id });
        return NoContent();
    }
    }
}