using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Notifications;

public class CreateNotificationDto : INotificationDto
{
    public bool IsRead { get; set; } = false;
    public string Content { get; set; } = "";
    public int UserId { get; set; }
}
