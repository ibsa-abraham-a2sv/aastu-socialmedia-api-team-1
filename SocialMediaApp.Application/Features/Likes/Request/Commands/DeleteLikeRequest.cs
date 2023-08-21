﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Likes.Request.Commands
{
    public class DeleteLikeRequest:IRequest<Unit>
    {
        public int LikeId { get; set; }
        public int UserId { get; set; }

    }
}