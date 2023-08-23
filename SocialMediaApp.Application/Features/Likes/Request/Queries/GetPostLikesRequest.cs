using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Application.DTOs.Likes;

namespace SocialMediaApp.Application.Features.Likes.Request.Queries
{
    public class GetPostLikesRequest:IRequest<List<LikeDto>>
    {
        public int UserId {get; set;}
        public int Id {get; set;}
    }
}