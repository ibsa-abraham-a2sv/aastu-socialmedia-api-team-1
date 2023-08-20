using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Notifications.Validators;

public class INotificationDtoValidator :AbstractValidator<INotificationDto>
{
    private readonly INotificationRepository _notificationRepository;
    public INotificationDtoValidator(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
        RuleFor(n => n.Content)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        RuleFor(n => n.UserId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var UserIdExists = await _notificationRepository.Exists(id);
                return !UserIdExists;
            })
            .WithMessage("{PropertyName} does not exist.");
    }
}
