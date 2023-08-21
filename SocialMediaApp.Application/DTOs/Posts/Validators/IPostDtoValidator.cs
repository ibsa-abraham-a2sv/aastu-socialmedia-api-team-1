using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Posts.Validators
{
    public class IPostDtoValidator : AbstractValidator<IPostDto>
    {
        private readonly IPostRepository _likeRepository;
        public IPostDtoValidator(IPostRepository likeRepository)
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

        }
    }
}
