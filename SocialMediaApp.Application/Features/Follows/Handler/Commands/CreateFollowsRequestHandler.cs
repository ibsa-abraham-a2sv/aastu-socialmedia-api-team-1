using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SocialMediaApp.Application.Features.Follows.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Application.Features.Follows.Handler.Commands;

public class CreateFollowsRequestHandler: IRequestHandler<CreateFollowsRequest, int>
{
    private readonly IFollowRepository _followRepository;
    private readonly IMapper _mapper;

    public CreateFollowsRequestHandler(IFollowRepository followRepository, IMapper mapper)
    {
        _followRepository = followRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateFollowsRequest request, CancellationToken cancellationToken)
    {
        var follow = _mapper.Map<Follow>(request);
        await _followRepository.Add(follow);
        return follow.Id;
    }

}
