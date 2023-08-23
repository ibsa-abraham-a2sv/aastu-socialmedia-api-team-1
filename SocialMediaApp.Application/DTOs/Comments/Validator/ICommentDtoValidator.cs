using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Comments.Validator
{
    public class ICommentDtoValidator : AbstractValidator<ICommentDto>
    {
        private readonly ICommentRepository _commentRepository;

        public ICommentDtoValidator(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;

            RuleFor(n => n.UserId)
               .GreaterThan(0)
               .MustAsync(async (id, token) =>
               {
                   var UserIdExists = await _commentRepository.Exists(id);
                   return UserIdExists;
               })
               .WithMessage("{PropertyName} does not exist.");

            RuleFor(n => n.PostId)
               .GreaterThan(0)
               .MustAsync(async (id, token) =>
               {
                   var PostIdExists = await _commentRepository.Exists(id);
                   return PostIdExists;
               })
               .WithMessage("{PropertyName} does not exist.");

            RuleFor(n => n.Text)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }

    }
}
