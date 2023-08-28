using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.UnitTest.Mocks;
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
using MediatR;


namespace test.UnitTest.Users.Commands
{
    public class UpdateUserRequestHandlerTest
    {
        private readonly IMapper _mapper;

        private readonly Mock<IUserRepository> _mockRepoUser;

        private readonly UpdateUserCommandRequestHandler _handler;

        private readonly UpdateUserDto _updateUserDto;
        private readonly Guid _userId;



        [Fact]
        public async Task UpdateuserTest()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    Name = "Jima Dube",
                    email = "jimd@gmail.com",
                    password = "High123@",
                },
                new User
                {
                    Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc6"),
                    Name = "xBebe",
                    email = "bebe@gmail.com",
                    password = "bebe123#",
                }
            };


            // Arrange
            var userId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc6");
            var updateUserDto = new UpdateUserDto
            {
                Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc4"),
                Name = "Jima Dube",
                email = "jima@gmail.com",
                Bio = "I like the picture:)"
            };

            var mockUserRepository = new Mock<IUserRepository>();
            var mockMapper = new Mock<IMapper>();
            
            // Configure mock behavior (replace this with your actual behavior)
            mockUserRepository.Setup(repo => repo.GetById(userId))
                            .ReturnsAsync(users[1]);

            // mockUserRepository.Setup(repo => repo.GetAll()).ReturnsAsync(() => users);
            
            var handler = new UpdateUserCommandRequestHandler(mockUserRepository.Object, mockMapper.Object);
            var request = new UpdateUserCommandRequest { Id = userId, UpdateUserDto = updateUserDto };

            // Act & Assert
            await handler.Handle(request, CancellationToken.None);
            mockUserRepository.Verify(repo => repo.GetById(userId), Times.Once);
            

         } 
    }
}