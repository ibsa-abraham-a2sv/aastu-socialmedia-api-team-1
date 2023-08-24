using SocialMediaApp.Application.Features.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Register(string Name, string Email, string Password);
        AuthenticationResult Login(string Email, string Password);

    }
}
