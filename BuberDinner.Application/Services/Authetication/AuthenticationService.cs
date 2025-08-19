namespace BuberDinner.Application.Services.Authetication;

public class AuthenticationService : IAuthenticationService
{
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
        return new AuthenticationResult(
            Id: Guid.NewGuid(),
            FirstName: firstName,
            LastName: lastName,
            Email: email,
            Token: "sample-token-456");
    }
}