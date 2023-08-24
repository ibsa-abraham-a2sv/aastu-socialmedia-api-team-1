using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.Features.NewsFeedItem.Request.Queries;
using SocialMediaApp.Application.Services.NewsFeedServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFeedController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly NewsFeedServices _newsFeedService;


        public NewsFeedController(IMediator mediator)
        {
            _mediator = mediator;
        }



        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetNewsFeedItemRequest()
        {
            var newsFeedItems = await _mediator.Send(new GetNewsFeedItemRequest());

            return newsFeedItems;
        }

    }
}
