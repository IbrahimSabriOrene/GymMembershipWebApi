using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Entities;
using MemberInfo.Domain.Common.Interfaces.Services;

namespace Customer.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly IDbContext _dbContext;
    public UserRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateUser(User user)
    {
        await _dbContext.EditDataAsync("INSERT INTO dbo.users (id, firstName, lastName, email, passwordHash) VALUES (@id, @firstName, @lastName, @email, @passwordHash)",user);


    }

    public async Task<int> DeleteUser(Guid id)
    {
        var deleteUser = await _dbContext.EditDataAsync("DELETE FROM dbo.users WHERE id=@Id", new { id });
        return deleteUser;
    }

    public async Task<bool> IsUserExists(string email)
    {
        var userCount = await _dbContext.EditDataAsync("SELECT COUNT(*) FROM dbo.users WHERE email=@email", new { email });
        if (userCount == 0)
        {
            return false;
        }
        return true;
        //if this is true, then the email is and this means that the user already exists
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _dbContext.GetAsync<User>("SELECT * FROM dbo.users where email=@email",
            new { email });
        if (user == null)
        {
            throw new Exception("No user found"); //Null exception
        }
        return user;
    }
}