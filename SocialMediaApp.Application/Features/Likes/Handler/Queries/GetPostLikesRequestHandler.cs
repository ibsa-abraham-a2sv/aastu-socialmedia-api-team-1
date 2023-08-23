using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Likes;
using SocialMediaApp.Application.Features.Likes.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Features.Likes.Request.Queries;

namespace SocialMediaApp.Application.Features.Likes.Handler.Queries
{
    public class GetPostLikesRequestHandler:IRequestHandler<GetPostLikesRequest, List<LikeDto>>
    {

        public readonly ILikeRepository _likeRepository;
        public readonly IMapper _mapper; 

        public GetPostLikesRequestHandler(ILikeRepository likeRepository,IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
            
        }
        public async Task<List<LikeDto>> Handle(GetPostLikesRequest request, CancellationToken cancellationToken)
        {
            var like = await _likeRepository.GetLikesByPostId(request.UserId, request.Id);
            return _mapper.Map<List<LikeDto>>(like);
        }
    }

        
}
