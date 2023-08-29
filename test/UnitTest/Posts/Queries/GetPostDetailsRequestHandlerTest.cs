using AutoMapper;
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
   

    public class GetPostDetailsRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepo;

        public GetPostDetailsRequestHandlerTest()
        {
            _mockRepo = MockRepositoryFactory.GetPostRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

        }

        [Fact]
        public async Task GetPostDetailTest()
        {
            var handler = new GetPostDetailsRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetPostRequestById(), CancellationToken.None);

            result.ShouldBeOfType<PostDto>();
            



        }


    }
}
