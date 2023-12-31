﻿using AutoMapper;
using Microsoft.Extensions.Options;
using Moq;
using Shouldly;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.Features.Posts.Handler.Queries;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.UnitTest.Mocks;

namespace test.UnitTest.Posts.Queries
{
    public class GetPostsRequestHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepo;

        public GetPostsRequestHandlerTest()
        {
            _mockRepo = MockRepositoryFactory.GetPostRepository();
            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetPostsTest()
        {
            var handler = new GetPostsRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetPostsRequestByUser(), CancellationToken.None);

            result.ShouldBeOfType<List<PostDto>>();
            

        }

    }
}
