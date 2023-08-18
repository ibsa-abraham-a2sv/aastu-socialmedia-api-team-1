using AutoMapper;
using MediatR;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Notifications.Handler.Commands;

public class CreateNotificationRequestHandler : IRequestHandler<CreateNotificationRequest, int>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;
    public CreateNotificationRequestHandler(INotificationRepository notificationRepository, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateNotificationRequest request, CancellationToken cancellationToken)
    {
        var notification = _mapper.Map<Notification>(request.CreateNotificationDto);
        notification = await _notificationRepository.Add(notification);
        return notification.Id;
    }

}
