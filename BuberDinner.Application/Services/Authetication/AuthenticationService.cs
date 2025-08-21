using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authetication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }

    public AuthenticationResult LoginAsync(
        string email,
        string password)
    {
        // 1. Validate user exists
        var user = this.userRepository.GetUserByEmail(email);

        if (user is null)
        {
            throw new InvalidOperationException("User does not exist.");
        }

        // 2. Validate password (this is a simplified example, in real applications use hashed passwords)
        if (user.Password != password)
        {
            throw new InvalidOperationException("Invalid password.");
        }

        // 3. Generate JWT token
        string token = this.jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
                        User: user,
                        Token: token);
    }

    public AuthenticationResult RegisterAsync(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        // 1. Validate the user does not already exist
        if (this.userRepository.GetUserByEmail(email) is not null)
        {
            throw new InvalidOperationException("User already exists.");
        }

        // 2. Create user (generate unique ID) & Persist to Database
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        this.userRepository.AddUser(user);

        // Generate JWT token
        string token = this.jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            User: user,
            Token: token);
    }
}