using AutoMapper;
using FluentValidation;
using MediatR;
using SocialMediaApp.Application.DTOs.Likes.Validators;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Likes.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Likes.Handler.Commands;

public class CreateLikeCommandHandler : IRequestHandler<CreateLikeRequest, int>
{
    private readonly ILikeRepository _likeRepository;
    private readonly IMapper _mapper;

    public CreateLikeCommandHandler(ILikeRepository likeRepository,IMapper mapper)
    {
        _likeRepository = likeRepository;
        _mapper = mapper;
        
    }

    public async Task<int> Handle(CreateLikeRequest request, CancellationToken cancellationToken)
    {
       
        var like = _mapper.Map<Like>(request.LikeDto);
        like = await _likeRepository.Add(like);

        if (_likeRepository.LikeExists(like.UserId, like.PostId)){

            throw new BadRequestException("Bad Request");
        }
   
        return like.Id;
    }
}
