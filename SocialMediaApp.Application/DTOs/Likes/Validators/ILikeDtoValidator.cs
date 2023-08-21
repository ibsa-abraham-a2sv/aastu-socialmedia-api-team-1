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
    public class ILikeDtoValidator: AbstractValidator<ILikeDto>
    {
        private readonly ILikeRepository _likeRepository;
        public ILikeDtoValidator(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
            RuleFor(n => n.UserId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var UserIdExists = await _likeRepository.Exists(id);
                return !UserIdExists;
            })
            .WithMessage("{PropertyName} does not exist.");

            RuleFor(n => n.PostId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var UserIdExists = await _likeRepository.Exists(id);
                return !UserIdExists;
            })
            .WithMessage("{PropertyName} does not exist.");
        }
    }

}

