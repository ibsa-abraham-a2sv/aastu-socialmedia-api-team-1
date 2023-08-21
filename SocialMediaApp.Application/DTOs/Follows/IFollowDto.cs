using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Follows
{
    public interface IFollowDto
    {
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
    }
}