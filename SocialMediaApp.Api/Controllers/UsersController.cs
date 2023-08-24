using Microsoft.AspNetCore.Mvc;
using MediatR;
using SocialMediaApp.Application.DTOs.Users;
using SocialMediaApp.Application.Features.Users.Request.Queries;
using SocialMediaApp.Application.Features.Users.Request.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Features.Follows.Request.Queries;
using SocialMediaApp.Application.Features.Notifications.Request.Queries;


namespace SocialMediaApp.Api.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class UsersController:ControllerBase
{
    private readonly IMediator _mediator;


    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
        
    }

    // GET: api/items
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> Get()
    {
        var users = await _mediator.Send(new GetUsersRequest());
        return users;
    }

    // GET: api/items/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById(int id)
    {
        var user = await _mediator.Send(new GetUserRequest {Id = id});
        var posts = await _mediator.Send(new GetPostsRequestByUser { UserId = id });
        var follows=  await _mediator.Send(new GetFollowingRequest { userId = id });
        var notifications = await _mediator.Send(new GetNotificationsRequest { UserId = id });
        if (user != null)
        {
            user.Post = posts;
            user.Followers = follows;
            user.Notifications = notifications;

        }



        return user;
    }
    //Get:user/name
    [HttpGet("search")]
    public async Task<ActionResult<List<UserDto>>> GetByNameAsync(string name)
    {
        var users = await _mediator.Send(new GetUsersByNameRequest{Name = name});
        return users;
    }
    // POST: api/items
    [HttpPost]
    public async Task<ActionResult> PostUsers([FromBody] CreateUserDto  createUserDto)
    {
        var usercommand = new CreateUserRequest{CreateUserDto = createUserDto};
        
        var userRespond = await _mediator.Send(usercommand);

        return Ok(userRespond);

    }

    // PUT: api/items/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int id,UpdateUserDto updateUser )
    {
        var NewUser = new UpdateUserCommandRequest{Id = id,UpdateUserDto = updateUser};
        await _mediator.Send(NewUser);

        return NoContent();
    }

    // DELETE: api/items/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        await _mediator.Send( new DeleteUserCommandRequest{ Id = id });
        return NoContent();
    }
}
}
