using MediatR;
using SocialMediaApp.Application.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.NewsFeedItem.Request.Queries
{
    public class GetNewsFeedItemRequest:IRequest<List<PostDto>>
    {
        public int UserId { get; set; }
    }
}
