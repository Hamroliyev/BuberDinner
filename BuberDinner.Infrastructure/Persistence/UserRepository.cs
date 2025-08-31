using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.User;

namespace  BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> users = new();
    public void AddUser(User user)
    {
        users.Add(user);
    }

    public User GetUserByEmail(string email)
    {
        return users.SingleOrDefault(u => u.Email == email);
    }
}