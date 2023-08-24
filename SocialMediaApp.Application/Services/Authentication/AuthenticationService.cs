using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Persistence.Contracts.Common;
using SocialMediaApp.Domain;
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

        private readonly IUserRepository _userRepository;
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }



        // check if user exists in database
        public AuthenticationResult Register(string Name, string Email, string password)
        {
            // validate if the user email does not exist

            if (_userRepository.GetByEmail(Email) is not  null)
            {
                throw new Exception("User with the given email already exists");
            }

            // create a new user (generate unique Id ) and add it to the database

            var user = new User
            {
                Name = Name,
                email = Email,
                password = password
            };


            _userRepository.AddUser(user);

           
            var token = _jwtTokenGenerator.GenerateToken(user.Id, Name);

            return new AuthenticationResult(
                user.Id,
                Email,
                Name,
                token);
        }

        public AuthenticationResult Login(string Email, string password)
        {
            //validate if the user exists

            if (_userRepository.GetByEmail(Email) is not User user)
            {
                throw new Exception("User with the given email does not exist");
            }
            // validate if the password is correct

            if (user.password != password)
            {
                throw new Exception("Password is incorrect");
            }

            // generate token

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Name);

            return new AuthenticationResult(
                Guid.NewGuid(),
                Email,
                "Name",
                "token");
        }
    }
}
