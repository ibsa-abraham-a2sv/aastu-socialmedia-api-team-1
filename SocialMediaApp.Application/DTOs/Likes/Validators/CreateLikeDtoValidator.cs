using FluentValidation;
using SocialMediaApp.Application.DTOs.Notifications.Validators;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Likes.Validators
{
    public class CreateLikeDtoValidator:AbstractValidator<CreateLikeDto>
    {
        private readonly IPostRepository _postRepository;
        public CreateLikeDtoValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;
            Include(new ILikeDtoValidator(_postRepository));
          
        }
    }
}
