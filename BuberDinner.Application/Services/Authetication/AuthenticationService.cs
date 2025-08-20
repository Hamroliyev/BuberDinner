using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authetication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult LoginAsync(
        string email,
        string password)
    {
        return new AuthenticationResult(
            Id: Guid.NewGuid(),
            FirstName: "John",
            LastName: "Doe",
            Email: email,
            Token: "sample-token-123");
    }

    public AuthenticationResult RegisterAsync(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        // Check if user already exists

        // Create user (generate a new user ID, etc.)

        // Generate JWT token
        Guid userId = Guid.NewGuid();
        string token = this.jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(
            Id: userId,
            FirstName: firstName,
            LastName: lastName,
            Email: email,
            Token: token);
    }
}