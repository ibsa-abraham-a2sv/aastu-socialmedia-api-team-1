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

public class UpdateNotificationRequestHandler : IRequestHandler<UpdateNotificationRequest, Unit>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;
    public UpdateNotificationRequestHandler(INotificationRepository notificationRepository, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateNotificationRequest request, CancellationToken cancellationToken)
    {
        var notification = await _notificationRepository.GetNotificationDetails(request.UpdateNotificationDto.UserId, request.UpdateNotificationDto.Id);
        if (notification != null)
        {
            _mapper.Map(notification,request.UpdateNotificationDto);
            await _notificationRepository.Update(notification);
        }
        return Unit.Value;
    }
}
