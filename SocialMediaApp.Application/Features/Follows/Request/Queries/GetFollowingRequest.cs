using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SocialMediaApp.Application.DTOs.Follows;


namespace SocialMediaApp.Application.Features.Follows.Request.Queries
{
    public class GetFollowingRequest:IRequest<List<FollowDto>>
    {
        public int userId { get; set; }
        public int Id {get; set;}
        
    }
}