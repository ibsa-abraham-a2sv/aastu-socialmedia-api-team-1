using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Comments
{
    public  interface ICommentDto
    {
        public string? Text { get; set; }

        public int UserId { get; set; }
        public int PostId { get; set; }

    }
}
