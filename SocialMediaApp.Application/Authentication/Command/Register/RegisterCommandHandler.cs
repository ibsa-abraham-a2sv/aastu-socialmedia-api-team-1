using MediatR;
using SocialMediaApp.Application.Persistence.Contracts.Common;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SocialMediaApp.Application.Authentication.Common;

namespace SocialMediaApp.Application.Authentication.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            
            // validate if the user email does not exist

            if (_userRepository.GetByEmail(command.Email) is not null)
            {
                throw new Exception("User with the given email already exists");
            }

            // create a new user (generate unique Id ) and add it to the database

            var user = new User
            {
                Name = command.Name,
                email = command.Email,
                password = command.Password,
                Bio = "",

            };


            _userRepository.AddUser(user);


            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
