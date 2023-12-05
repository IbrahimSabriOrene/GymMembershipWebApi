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

    /*
    CREATE TABLE users (
    id UNIQUEIDENTIFIER PRIMARY KEY,
    firstName VARCHAR(50),
    lastName VARCHAR(50),
    email VARCHAR(100)
    );  
    */

    public async Task<bool> CreateUser(User user)
    {
        var result = await _dbContext.EditDataAsync("INSERT INTO dbo.users (id, firstName, lastName, email) VALUES (@id, @firstName, @lastName, @email)",
            user);
        return true;
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var deleteUser = await _dbContext.EditDataAsync("DELETE FROM dbo.users WHERE id=@Id", new { id });
       
        return true;
    }

    public async Task<bool> IsEmailValid(string email)
    {
        var user = await _dbContext.EditDataAsync("SELECT FROM dbo.users WHERE email=@email", new { email });
        return true;
    }
    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _dbContext.GetAsync<User>("SELECT * FROM dbo.users where email=@email",
            new { email });
        return user;
    }

    public async Task<bool> ChangeFirstName(User user)
    {
        var isFirstName =
            await _dbContext.EditDataAsync(
                "Update dbo.users SET firstName=@firstName WHERE id=@Id",
                user);
        return true;
    }

    public async Task<bool> ChangeLastName(User user)
    {
        var isLastName =
            await _dbContext.EditDataAsync(
                "Update dbo.users SET lastName=@lastName WHERE id=@Id",
                user);
        return true;
    }
    public async Task<bool> ChangeEmail(User user) 
    //Change email sends a verification email to the new email address
    //Email change is once a month
    {
        var changeEmail =
           await _dbContext.EditDataAsync(
               "Update dbo.users SET email=@email WHERE id=@Id",
               user);
        return true;
    }

    
    //
    // public async Task<bool> CreateUser(User person)
    // {
    //     var result =
    //         await _dbContext.EditDataAsync(
    //             "INSERT INTO public.user (id,name, age, address, mobile_number) VALUES (@Id, @Name, @Age, @Address, @MobileNumber)",
    //             person);
    //     return true;
    // }
    //
    // public async Task<List<User>> CreateUser()
    // {
    //     var userList = await _dbContext.GetAll<User>("SELECT * FROM public.user", new { });
    //     return userList;
    // }
    //
    //
    // public async Task<User> GetUser(int id)
    // {
    //     var userList = await _dbContext.GetAsync<User>("SELECT * FROM public.user where id=@id", new { id });
    //     return userList;
    // }
    //
    // public async Task<User> UpdateUser(User user)
    // {
    //     var updateUser =
    //         await _dbContext.EditDataAsync(
    //             "Update public.user SET firstName=@firstName, lastName=@lastName, email=@email WHERE id=@Id",
    //             user);
    //     return user;
    // }
    //
    // public async Task<bool> DeleteUser(int id)
    // {
    //     //This part gonna change
    //     var deleteUser = await _dbContext.EditDataAsync("DELETE FROM public.user WHERE id=@Id", new { id });
    //     return true;
    // }
    //
    // public async Task<User>? GetUserByEmail(string email)
    // {
    //     var user = await _dbContext.GetAsync<User>("SELECT * FROM public.user where email=@email", new { email });
    //     return user;
    // }
    //
}
