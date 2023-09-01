using MemberInfo.Domain.Common.Interfaces.Persistence;
using MemberInfo.Domain.Entities;

namespace MemberInfo.Infrastructure.Persistence;

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
