using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Follows
{
    public interface IFollowDto
    {
    public int CurrentUser { get; set; }
    public int ToBeFollowed { get; set; }
    }
}