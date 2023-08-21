using SocialMediaApp.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Comments;

public class CommentDto : BaseDto
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string? Text { get; set; }

}
