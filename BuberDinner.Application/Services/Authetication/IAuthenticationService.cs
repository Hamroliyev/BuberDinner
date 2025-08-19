namespace BuberDinner.Application.Services.Authetication;

public interface IAuthenticationService
{
    AuthenticationResult RegisterAsync(
        string firstName,
        string lastName,
        string email,
        string password);
    AuthenticationResult LoginAsync(
        string email,
        string password);
}
