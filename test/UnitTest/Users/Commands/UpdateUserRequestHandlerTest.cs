using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.UnitTest.CommentTest.Mocks;
using AutoMapper;
using Moq;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Features.Users.Handler.Commands;
using SocialMediaApp.Application.Features.Users.Request.Commands;
using SocialMediaApp.Application.DTOs.Users;
using SocialMediaApp.Application.Responses;
using SocialMediaApp.Application.Profiles;   
using Shouldly;
using SocialMediaApp.Application.Features.Users.Handler.Commands;
using SocialMediaApp.Application.Features.Users.Request.Commands;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Users.Handler.Commands;


namespace test.UnitTest.Users.Commands
{
    public class UpdateUserRequestHandlerTest
    {
        private readonly IMapper _mapper;

        private readonly Mock<IUserRepository> _mockRepoUser;

        private readonly UpdateUserCommandRequestHandler _handler;

        private readonly UpdateUserDto _updateUserDto;


        public UpdateUserRequestHandlerTest()
        {

            _mockRepoUser = MockRepositoryFactory.GetUserRepository();

            _handler = new UpdateUserCommandRequestHandler(_mockRepoUser.Object, _mapper);


            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();  


            _updateUserDto = new UpdateUserDto
            {
                Name = "Jima Dube",
                email = "jima@gmail.com",
                Bio = "I like the picture:)"
            };

        }
    }
}