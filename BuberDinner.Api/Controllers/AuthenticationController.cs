using BuberDinner.Application.Services.Authetication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            var authResult = this.authenticationService.RegisterAsync(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            var response = new AuhtecticationResponse(
                Id: authResult.User.Id,
                FirstName: authResult.User.FirstName,
                LastName: authResult.User.LastName,
                Email: authResult.User.Email,
                Token: authResult.Token
            );

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var authResult = this.authenticationService.LoginAsync(
                request.Email,
                request.Password);
            
            var response = new AuhtecticationResponse(
                Id: authResult.User.Id,
                FirstName: authResult.User.FirstName,
                LastName: authResult.User.LastName,
                Email: authResult.User.Email,
                Token: authResult.Token);

            return Ok(response);
        }
    }
}