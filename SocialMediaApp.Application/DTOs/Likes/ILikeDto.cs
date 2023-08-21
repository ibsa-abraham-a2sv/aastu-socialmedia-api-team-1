using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Likes
{
    public interface ILikeDto
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
