using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Follows;

public class CreateFollowDto : IFollowDto
{
    public Guid FollowerId { get; set; }
    public Guid FollowingId { get; set; }
}
