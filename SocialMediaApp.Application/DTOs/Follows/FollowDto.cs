﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Application.DTOs.Common;

namespace SocialMediaApp.Application.DTOs.Follows;

public class FollowDto:BaseDto,IFollowDto
{
    public Guid FollowerId { get; set; }
    public Guid FollowingId { get; set; }
    // public User Follower { get; set; }
    // public User Following { get; set; }
}
