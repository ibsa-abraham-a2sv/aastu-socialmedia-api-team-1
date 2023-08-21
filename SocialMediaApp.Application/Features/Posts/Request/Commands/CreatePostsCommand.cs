﻿using MediatR;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Posts.Request.Commands;

public class CreatePostsCommand: IRequest<int>
{
    public PostDto postDto { get; set; }
}
