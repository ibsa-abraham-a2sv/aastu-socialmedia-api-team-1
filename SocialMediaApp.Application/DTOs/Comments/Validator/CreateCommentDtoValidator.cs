using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Comments.Validator
{
    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        private readonly ICommentRepository _commentRepository;
        public CreateCommentDtoValidator(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            Include(new ICommentDtoValidator(_commentRepository));
        }
    }
}
