using SocialMediaApp.Application.Persistence.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Services.Authentication
{


    internal class AuthenticationService : IAuthenticationService
    {

        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }



        // check if user exists in database
        public AuthenticationResult Register(string Name, string Email, string password)
        {

            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), Name);

            return new AuthenticationResult(
                Guid.NewGuid(),
                Email,
                Name,
                token);
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
