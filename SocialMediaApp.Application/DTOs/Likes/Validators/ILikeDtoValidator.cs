using FluentValidation;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Likes.Validators
{
    public class ILikeDtoValidator: AbstractValidator<ILikeDto> {
        private readonly IPostRepository _postRepository;
        public ILikeDtoValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;
            RuleFor(n => n.UserId)
            .GreaterThan(0)
            .WithMessage("{PropertyName} does not exist.");

            RuleFor(n => n.PostId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var UserIdExists = await _postRepository.Exists(id);
                return UserIdExists;
            })
            .WithMessage("{PropertyName} does not exist.");
        }
    }

}

