using MediatR;
using SocialMediaApp.Application.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Posts.Request.Queries
{
    public class GetPostsRequestById : IRequest<List<PostDto>>
    {
        
        public int PostId { get; set; }
    }
}
