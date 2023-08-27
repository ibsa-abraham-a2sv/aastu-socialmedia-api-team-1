using System.ComponentModel;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMediaApp.Application.Features.Notifications.Request.Queries;
using SocialMediaApp.Application.Features.Notifications.Handler.Queries;
using test.UnitTest.CommentTest.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Profiles;


namespace test.UnitTest.Notifications.Queries
{
    public class GetNotificaitonHandlerTest
    {
                private  readonly IMapper _mapper;
        private readonly Mock<INotificationRepository> _mockRepo;
        
        private readonly GetNotificationsRequestHandler _handler;
        public GetNotificaitonHandlerTest()
        {
            _mockRepo = MockRepositoryFactory.GetNotificationRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task  GetNotificationTest()
        {
            // Given
            var result = await _handler.Handle(new GetNotificationsRequest(){UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc6")}, CancellationToken.None);

            // When
            result.ShouldBeOfType<List<NotificationDto>>();
            result.Count.ShouldBe(0);
        }
    }
}