<<<<<<< HEAD
﻿using System;
=======
﻿using MediatR;
using SocialMediaApp.Application.DTOs.Comments;
using System;
>>>>>>> origin/mikeyas_branch
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Comments.Request.Commands;

<<<<<<< HEAD
public class CreateCommentRequest
{
=======
public class CreateCommentRequest : IRequest<int>
{
    public CommentDto? creatCommentDto { get; set; }
>>>>>>> origin/mikeyas_branch
}
