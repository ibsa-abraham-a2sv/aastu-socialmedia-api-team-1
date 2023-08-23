using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using SocialMediaApp.Application.DTOs.Follows;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.Features.NewsFeedItem.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.NewsFeedItem.Handler.Queries
{
    public class GetNewsFeedItemRequestHandler : IRequestHandler<GetNewsFeedItemRequest, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;

        public GetNewsFeedItemRequestHandler(IPostRepository postRepository, IFollowRepository followRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _followRepository = followRepository;
            _mapper = mapper;

            
        }

        public async Task<List<PostDto>> Handle(GetNewsFeedItemRequest request, CancellationToken cancellationToken)
        {
            var posts = _postRepository.GetPostForNewsFeed();
            var newsFeedItems = new List<PostDto>();
            foreach (var post in posts)
            {
                var follow =  _followRepository.GetById(post.UserId).Result;

                var newsFeedItem = new PostDto
                {
                    Title = post.Title,
                    Content = post.Content,
                    CreatedDate = post.CreatedDate

                };

               
                newsFeedItems.Add(newsFeedItem);
            }

            return _mapper.Map<List<PostDto>>(newsFeedItems);
        }
    }
}

