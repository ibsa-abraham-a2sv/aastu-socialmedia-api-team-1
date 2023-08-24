using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Services.Authentication
{
    public record AuthenticationResult(
               Guid Id,
               string Email,
               string Name,
               string Token);
}
