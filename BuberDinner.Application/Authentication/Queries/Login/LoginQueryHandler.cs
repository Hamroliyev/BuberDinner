using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository userRepository;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        LoginQuery request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the user exists
        if (this.userRepository.GetUserByEmail(request.Email) is not User user)
        {
            return Error.Failure(
                code: "Authentication.InvalidCredentials",
                description: "Invalid credentials.");
        }

        // 2. Validate the password is correct
        if (user.Password != request.Password)
        {
            return Error.Failure(
                code: "Authentication.InvalidCredentials",
                description: "Invalid credentials.");
        }

        // 3. Create JWT token
        var token = this.jwtTokenGenerator.GenerateToken(
            user);

        return new AuthenticationResult(
            User: user,
            Token: token);
    }
}