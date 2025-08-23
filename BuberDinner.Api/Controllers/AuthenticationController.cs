using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public AuthenticationController(
            IMediator mediator,
            IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            RegisterCommand command = mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = this.mediator.Send(command).Result;

            return authResult.Match(
                authResult => Ok(mapper.Map<AuhtecticationResponse>(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            LoginQuery query = mapper.Map<LoginQuery>(request);
            ErrorOr<AuthenticationResult> authResult = this.mediator.Send(query).Result;

            return authResult.Match(
                authResult => Ok(mapper.Map<AuhtecticationResponse>(authResult)),
                errors => Problem(errors));
        }
    }
}