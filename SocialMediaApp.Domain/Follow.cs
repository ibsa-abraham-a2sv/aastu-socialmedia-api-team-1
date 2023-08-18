using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Domain.Common;

namespace SocialMediaApp.Domain;

public class Follow : BaseEntity
{
    /*
    Int Id
Int FollowerId
Int FollowingId

    */
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
    // public User Follower { get; set; }
    // public User Following { get; set; }
}

