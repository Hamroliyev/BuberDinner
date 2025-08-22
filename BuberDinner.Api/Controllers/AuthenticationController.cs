using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            RegisterCommand command = new(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            ErrorOr<AuthenticationResult> authResult = this.mediator.Send(command).Result;

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            LoginQuery query = new(
                request.Email,
                request.Password);

            ErrorOr<AuthenticationResult> authResult = this.mediator.Send(query).Result;

            var response = MapAuthResult(authResult.Value);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }
        
         private static AuhtecticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuhtecticationResponse(
                            Id: authResult.User.Id,
                            FirstName: authResult.User.FirstName,
                            LastName: authResult.User.LastName,
                            Email: authResult.User.Email,
                            Token: authResult.Token
                        );
        }
    }
}