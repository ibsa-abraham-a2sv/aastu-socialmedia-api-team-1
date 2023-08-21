using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Features.Notifications.Request.Queries;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<NotificationController>
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<List<NotificationDto>>> Get(int userId)
        {
            var query = new GetNotificationsRequest { UserId = userId };
            var notifications = await _mediator.Send(query);
            return Ok(notifications);
        }

        // GET api/<NotificationController>/5
        [HttpGet("{userId:int},{id:int}")]
        public async Task<ActionResult<NotificationDto>> Get(int userId,int id)
        {
            var query = new GetNotificationDetailsRequest { UserId = userId, NotificationId = id };
            var notificaiton = await _mediator.Send(query);
            return Ok(notificaiton);
        }

        // POST api/<NotificationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateNotificationDto notificationDto)
        {
            var command = new CreateNotificationRequest { CreateNotificationDto = notificationDto };
            var response = await _mediator.Send(command);
            return Ok( response);
        }       

        // DELETE api/<NotificationController>/5
        [HttpDelete("{userId:int},{id:int}")]
        public async Task<ActionResult<int>> Delete(int userId,int id)
        {
            var command = new DeleteNotificationRequest { UserId = userId,NotificationId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
