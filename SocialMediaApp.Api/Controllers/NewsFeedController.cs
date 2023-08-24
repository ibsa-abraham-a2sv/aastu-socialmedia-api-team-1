using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Likes;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.Features.Comments.Request.Queries;
using SocialMediaApp.Application.Features.Follows.Request.Queries;
using SocialMediaApp.Application.Features.Likes.Request.Queries;
using SocialMediaApp.Application.Features.NewsFeedItem.Request.Queries;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Domain;
using System.Diagnostics.Metrics;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFeedController : ControllerBase
    {
        private readonly IMediator _mediator;
 


        public NewsFeedController(IMediator mediator)
        {
            _mediator = mediator;
        }



        // GET: api/<ValuesController>
        [HttpGet("{UserId:int}")]
        public async Task<ActionResult<List<PostListDto>>> GetNewsFeedItemRequest(int UserId)
        { 
            var newsFeedItems = new List<PostListDto>();
            var userFollowings = await _mediator.Send(new GetFollowerRequest { userId = UserId });
            Console.WriteLine(userFollowings.Count);
            foreach (var follower in userFollowings)
            {
                var posts = await _mediator.Send(new GetPostsRequestByUser { UserId = follower.FollowingId });
                foreach(var post in posts)
                {
                    var likes = await _mediator.Send(new GetLikesRequest { PostId = post.Id });
                    var comments = await _mediator.Send(new GetCommentListRequest { Id = post.Id });
                    var newsFeedItem = new PostListDto
                    {
                        Id = post.Id,
                        HashTag = post.HashTag,
                        Title = post.Title,
                        Content = post.Content,
                        Likes = likes.Count(),
                        CreatedDate = post.CreatedDate,
                        Comments = comments.Select(c => c.Text).ToList(),
                        UserId = post.UserId
                    };
                    newsFeedItems.Add(newsFeedItem);

                }
            }

            return Ok(newsFeedItems);
        }

        
      

    }
}
