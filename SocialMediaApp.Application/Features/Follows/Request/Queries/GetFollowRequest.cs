using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SocialMediaApp.Application.DTOs.Follows;

namespace SocialMediaApp.Application.Features.Follows.Request.Queries
{
    public class GetFollowRequest:IRequest<FollowDto>
    {
        public int Id { get; set; }
        
    }
}