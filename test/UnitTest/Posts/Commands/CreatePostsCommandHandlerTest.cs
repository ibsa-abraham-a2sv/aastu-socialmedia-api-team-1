using AutoMapper;
using Moq;
using Shouldly;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.DTOs.Users;
using SocialMediaApp.Application.Features.Posts.Handler.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Commands;
using SocialMediaApp.Application.Features.Users.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Profiles;
using SocialMediaApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.UnitTest.CommentTest.Mocks;

namespace test.UnitTest.Posts.Commands
{
    public class CreatePostsCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepo ;
        private readonly CreatePostsCommandHandler _handler;
        private readonly CreatePostDto _createPostDto;

        public CreatePostsCommandHandlerTest()
        {
            _mockRepo = MockRepositoryFactory.GetPostRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _createPostDto = new CreatePostDto
            {
                UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                Title = "Test",
                Content = "Test_content",
                HashTag = new List<String> { "Test", "Frist_Test", "Sample" }
            };
        }

        [Fact]
        public async Task CreatePost()
        {
            var resultTask = _handler.Handle(new CreatePostsCommand(){postDto = _createPostDto }, CancellationToken.None);

            var result = await resultTask;
            

            result.ShouldBeOfType<BaseResponseClass>();

        }



        
    }
}
