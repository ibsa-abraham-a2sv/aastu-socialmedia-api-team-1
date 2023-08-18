using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SocialMediaApp.Application.Features.Follows.Request.Commands;

public class CreateFollowsRequest:IRequest<int>
{
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
    // public User Follower { get; set; }
    // public User Following { get; set; }
}
