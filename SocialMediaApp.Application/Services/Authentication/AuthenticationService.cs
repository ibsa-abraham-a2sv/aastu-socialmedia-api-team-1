using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Services.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResult Register(string Name, string Email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                Email,
                Name,
                "token");
        }

        public AuthenticationResult Login(string Email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                Email,
                "Name",
                "token");
        }
    }
}
