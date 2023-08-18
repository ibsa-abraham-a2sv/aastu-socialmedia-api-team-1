using AutoMapper;
using MediatR;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Notifications.Handler.Commands;

public class DeleteNotificationRequestHandler : IRequestHandler<DeleteNotificationRequest, Unit>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;
    public DeleteNotificationRequestHandler(INotificationRepository notificationRepository, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteNotificationRequest request, CancellationToken cancellationToken)
    {
        var notification = await _notificationRepository.GetNotificationDetails(request.UserId, request.NotificationId);
        if (notification != null) { 
            await _notificationRepository.Delete(notification);
        }
        return Unit.Value;
    }
}
