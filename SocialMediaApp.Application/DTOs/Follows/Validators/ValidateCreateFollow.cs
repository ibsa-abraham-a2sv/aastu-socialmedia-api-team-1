using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;


namespace SocialMediaApp.Application.DTOs.Follows.Validators
{
    public class ValidateCreateFollow:AbstractValidator<FollowDto>
    {
        private readonly IFollowRepository _followRepository;
        public ValidateCreateFollow(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
            Include(new IFollowDtoValidator(_followRepository));
        }
        
    }
}