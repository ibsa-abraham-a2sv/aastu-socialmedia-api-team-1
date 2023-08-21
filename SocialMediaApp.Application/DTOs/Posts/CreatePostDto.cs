using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Posts
{
    public class CreatePostDto
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }


        public List<Comment> comments { get; set; }

    }
}
