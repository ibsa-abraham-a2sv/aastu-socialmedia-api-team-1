<<<<<<< HEAD
﻿using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Likes;
using SocialMediaApp.Application.Features.Likes.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
=======
﻿using System;
>>>>>>> origin/mikeyas_branch
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Likes.Handler.Queries;

<<<<<<< HEAD
public class GetLikesRequestHandler : IRequestHandler<GetLikesRequest, List<LikeDto>>
{
    public readonly ILikeRepository _likeRepository;
    public readonly IMapper _mapper; 
    public GetLikesRequestHandler(ILikeRepository likeRepository,IMapper mapper)
    {
        _likeRepository = likeRepository;
        _mapper = mapper;
        
    }
    public async Task<List<LikeDto>> Handle(GetLikesRequest request, CancellationToken cancellationToken)
    {
        var like = await _likeRepository.GetAll();
        return _mapper.Map<List<LikeDto>>(like);
    }
=======
public class GetLikesRequestHandler
{
>>>>>>> origin/mikeyas_branch
}
