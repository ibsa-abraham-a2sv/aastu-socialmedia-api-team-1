using MediatR;
using SocialMediaApp.Application.DTOs.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Likes.Request.Commands;

public class CreateLikesCommand: IRequest<int> 
{
    public LikeDto LikeDto { get; set; }
}
