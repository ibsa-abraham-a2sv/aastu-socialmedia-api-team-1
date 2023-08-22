using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using SocialMediaApp.Application.DTOs.Follows.Validators;
using SocialMediaApp.Application.Features.Follows.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Responses;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Application.Features.Follows.Handler.Commands;

public class CreateFollowsRequestHandler: IRequestHandler<CreateFollowsRequest, BaseResponseClass>
{
    private readonly IFollowRepository _followRepository;
    private readonly IMapper _mapper;

    public CreateFollowsRequestHandler(IFollowRepository followRepository, IMapper mapper)
    {
        _followRepository = followRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponseClass> Handle(CreateFollowsRequest request, CancellationToken cancellationToken)
    {
        var validator = new ValidateCreateFollow(_followRepository);

        var validationResult = await validator.ValidateAsync(request.createFollowDto);
        var response = new BaseResponseClass();


        if(validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            var follow = _mapper.Map<Follow>(request.createFollowDto);
            follow = await _followRepository.Add(follow);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = follow.Id;
        }


       
        
        return response;
    }

}
