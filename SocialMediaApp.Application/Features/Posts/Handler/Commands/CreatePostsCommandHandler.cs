using AutoMapper;
using MediatR;
using SocialMediaApp.Application.Features.Posts.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Posts.Handler.Commands;

public class CreatePostsCommandHandler : IRequestHandler<CreatePostsCommand,int>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public CreatePostsCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        
    }

    public async Task<int> Handle(CreatePostsCommand request, CancellationToken cancellationToken)
    {
        var post = _mapper.Map<Post>(request.postDto);
        post = await _postRepository.Add(post);
        return post.Id;
    }
}
