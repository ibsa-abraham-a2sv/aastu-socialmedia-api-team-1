using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Follows;
using SocialMediaApp.Application.Features.Follows.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;

namespace SocialMediaApp.Application.Features.Follows.Handler.Queries
{
    public class GetFollowRequestHandler : IRequestHandler<GetFollowRequest, FollowDto>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;

        public GetFollowRequestHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }
        public async Task<FollowDto> Handle(GetFollowRequest request, CancellationToken cancellationToken)
        {
            var follow = await _followRepository.GetById(request.Id);
            return _mapper.Map<FollowDto>(follow);
        }
    }
}