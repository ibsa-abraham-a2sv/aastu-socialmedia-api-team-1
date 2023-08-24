using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Application.DTOs.Common;

namespace SocialMediaApp.Application.DTOs.Follows;

public class FollowDto:IFollowDto
{
    public int CurrentUser { get; set; }
    public int ToBeFollowed { get; set; }
}
