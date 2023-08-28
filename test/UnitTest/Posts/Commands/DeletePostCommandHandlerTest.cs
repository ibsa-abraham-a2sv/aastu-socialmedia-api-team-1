using AutoMapper;
using Moq;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.UnitTest.CommentTest.Mocks;

namespace test.UnitTest.Posts.Commands
{
    public class DeletePostCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockRepo;
        public DeletePostCommandHandlerTest()
        {
            _mockRepo = MockRepositoryFactory.GetPostRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }
    }
}
