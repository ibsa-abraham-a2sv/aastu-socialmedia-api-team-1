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
        private readonly ILikeRepository _likeRepository;
        public CreateLikeDtoValidator(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
            Include(new ILikeDtoValidator(_likeRepository));
          
        }
    }
}
