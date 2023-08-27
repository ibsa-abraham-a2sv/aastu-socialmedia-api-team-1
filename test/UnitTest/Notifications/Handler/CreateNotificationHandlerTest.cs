using System.Runtime.InteropServices;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Features.Notifications.Handler.Commands;
using test.UnitTest.CommentTest.Mocks;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Persistence.Contracts;
using AutoMapper;
using Moq;
using Shouldly;
using SocialMediaApp.Application.Profiles;

namespace test.UnitTest.Notifications.Handler
{
    public class CreateNotificationHandlerTest
    {
        private  readonly IMapper _mapper;
        private readonly Mock<INotificationRepository> _mockRepoNotification;
        
        private readonly Mock<IUserRepository> _mockRepoUser;
        private readonly CreateNotificationRequestHandler _handler; 
        private readonly CreateNotificationDto _createNotificationDto;
        public CreateNotificationHandlerTest()
        {
            _mockRepoNotification = MockRepositoryFactory.GetNotificationRepository();
            _mockRepoUser = MockRepositoryFactory.GetUserRepository();
            _handler = new CreateNotificationRequestHandler(_mockRepoNotification.Object, _mapper, _mockRepoUser.Object);
            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _createNotificationDto = new CreateNotificationDto
            {
              Content = "xbebe follow you",
              UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc6")
            };
        }

        [Fact]
        public async Task  NotificationTest()
        {
            // Given
            var result = await _handler.Handle(new CreateNotificationRequest(){CreateNotificationDto = _createNotificationDto}, CancellationToken.None);

            // When
            // result.ShouldBeOfType<List<NotificationDto>>();
            // result.Count.ShouldBe(0);
        
            // Then
        }
    }
}