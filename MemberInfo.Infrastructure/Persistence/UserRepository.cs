using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Entities;
using Customer.Domain.Products.ValueObjects;

namespace Customer.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(u => u.Email == email);
    }

}
