using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;


namespace SocialMediaApp.Application.DTOs.Follows.Validators
{
    public class IFollowDtoValidator:AbstractValidator<IFollowDto>
    {
        private readonly IFollowRepository _followRepository;
        public IFollowDtoValidator(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
            RuleFor(n => n.FollowerId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var UserIdExists = await _followRepository.Exists(id);
                return !UserIdExists;
            })
            .WithMessage("{PropertyName} does not exist.");
            
            RuleFor(n => n.FollowingId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var UserIdExists = await _followRepository.Exists(id);
                return !UserIdExists;
            })
            .WithMessage("{PropertyName} does not exist.");

        }

       
        
    }
}