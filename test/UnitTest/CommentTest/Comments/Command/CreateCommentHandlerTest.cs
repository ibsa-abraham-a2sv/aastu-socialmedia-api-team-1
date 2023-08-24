using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.UnitTest.CommentTest.Mocks;
using AutoMapper;
using Moq;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Features.Comments.Handler.Queries;
using SocialMediaApp.Application.Features.Comments.Request.Queries;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.Profiles;   
using Shouldly;
using SocialMediaApp.Application.Features.Comments.Handler.Commands;
using SocialMediaApp.Application.Features.Comments.Request.Commands;


namespace test.UnitTest.CommentTest.Comments.Handler
{
    public class CreateCommentHandlerTest
    {
        private  readonly IMapper _mapper;
        private readonly Mock<ICommentRepository> _mockRepo;
        
        private readonly CreateCommentDto _createCommentDto;
        public CreateCommentHandlerTest()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();  

            _createCommentDto = new CreateCommentDto
            {
                UserId = 1,
                PostId = 2,
                Text = "I like the picture:)"
            };
        }


        [Fact]
        public async Task CreateComment()
        {
            // When
            var handler = new CreateCommentRequestHandler(_mockRepo.Object, _mapper);

            var result = handler.Handle(new CreateCommentRequest(){ creatCommentDto = _createCommentDto}, CancellationToken.None);

            var comments = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<CreateCommentDto>();


        
            // Then
        }
    }

}