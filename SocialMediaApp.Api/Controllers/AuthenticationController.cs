using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Application.Features.Authentication;
using SocialMediaApp.Application.Services.Authentication;

namespace SocialMediaApp.Api.Controllers
{
    


    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController( IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(
                request.Name,
                request.Email,
                request.Password);
            var authResponse = new AuthenticationResponse(
                authResult.Id,
                authResult.Email,
                authResult.Name,
                authResult.Token);
            return Ok(authResponse);
            
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(
                request.Email,
                request.Password);
            var authResponse = new AuthenticationResponse(
                authResult.Id,
                authResult.Email,
                authResult.Name,
                authResult.Token);
            return Ok(authResponse);
        }
    }
}
