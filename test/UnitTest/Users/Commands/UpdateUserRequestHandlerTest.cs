using System;
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
using SocialMediaApp.Domain;


namespace test.UnitTest.Users.Commands
{
    public class UpdateUserRequestHandlerTest
    {
        private readonly IMapper _mapper;

        private readonly Mock<IUserRepository> _mockRepoUser;

        private readonly UpdateUserCommandRequestHandler _handler;

        private readonly UpdateUserDto _updateUserDto;
        private readonly Guid _userId;

        public UpdateUserRequestHandlerTest()
        {

            _mockRepoUser = MockRepositoryFactory.GetUserRepository();

            _handler = new UpdateUserCommandRequestHandler(_mockRepoUser.Object, _mapper);


            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();  

            _userId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc4");
            _updateUserDto = new UpdateUserDto
            {
                Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc4"),
                Name = "Jima Dube",
                email = "jima@gmail.com",
                Bio = "I like the picture:)"
            };

        }


        [Fact]
        public async Task UpdateuserTest()
        {
            // Given
             
            // When
            //   var result = await _handler.Handle(new UpdateUserCommandRequest { Id = _userId, UpdateUserDto = _updateUserDto }, CancellationToken.None);
            //   var resultUsers = await _mockRepoUser.Object.GetAll(); 
            //  // Then
            //     resultUsers.Count.ShouldBe(0);
        }
    }
}