move these:

```csharp
 

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


    public async Task<bool> CreateUser(User user)
    {
        var result =
            await _dbContext.EditData("INSERT INTO public.employee (id,name, age, address, mobile_number) VALUES (@Id, @Name, @Age, @Address, @MobileNumber)",
                user);
        return true; 
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var deleteEmployee = await _dbContext.EditData("DELETE FROM public.employee WHERE id=@Id", new { id });
        //make if else : false true statement
        return true;
    }

    public async Task<bool>? GetUserByEmail(string email)
    {
        var user = await _dbContext.EditData("SELECT FROM public.email WHERE email=@email", new { email });
        //make if else : false true statement
        return true;
    }

    public async Task<bool> ChangeFirstName(User user)
    {
        var isFirstName =
            await _dbContext.EditData(
                "Update public.employee SET name=@Name, age=@Age, address=@Address, mobile_number=@MobileNumber WHERE id=@Id",
                user);
        return true;
    }

    public async Task<bool> ChangeLastName(User user)
    {
        var isLastName =
            await _dbContext.EditData(
                "Update public.employee SET name=@Name, age=@Age, address=@Address, mobile_number=@MobileNumber WHERE id=@Id",
                user);
        return true;
    }
    public async Task<bool> ChangeEmail(User user)
    {
        var changeEmail =
           await _dbContext.EditData(
               "Update public.employee SET name=@Name, age=@Age, address=@Address, mobile_number=@MobileNumber WHERE id=@Id",
               user);
        return true;
    }

    
    //
    // public async Task<bool> CreateUser(User person)
    // {
    //     var result =
    //         await _dbContext.EditData(
    //             "INSERT INTO public.employee (id,name, age, address, mobile_number) VALUES (@Id, @Name, @Age, @Address, @MobileNumber)",
    //             person);
    //     return true;
    // }
    //
    // public async Task<List<User>> CreateUser()
    // {
    //     var userList = await _dbContext.GetAll<User>("SELECT * FROM public.employee", new { });
    //     return userList;
    // }
    //
    //
    // public async Task<User> GetUser(int id)
    // {
    //     var userList = await _dbContext.GetAsync<User>("SELECT * FROM public.employee where id=@id", new { id });
    //     return userList;
    // }
    //
    // public async Task<User> UpdateUser(User user)
    // {
    //     var updateUser =
    //         await _dbContext.EditData(
    //             "Update public.employee SET name=@Name, age=@Age, address=@Address, mobile_number=@MobileNumber WHERE id=@Id",
    //             user);
    //     return user;
    // }
    //
    // public async Task<bool> DeleteUser(int id)
    // {
    //     //This part gonna change
    //     var deleteUser = await _dbContext.EditData("DELETE FROM public.employee WHERE id=@Id", new { id });
    //     return true;
    // }
    //
    // public async Task<User>? GetUserByEmail(string email)
    // {
    //     var user = await _dbContext.GetAsync<User>("SELECT * FROM public.employee where email=@email", new { email });
    //     return user;
    // }
    //
}

```




then when you complete everything includes validation. 

fix the product id system

One person have only 1 product id, 
1 product have multiple person id's

Change naming


list

start persontask


Revize api


Get users month inside the customer.

Instead of product's dateTime trick. No need.

What i really wanted is different than what i am going to do right now.

Change versions.


---Start making mappings in MemberInfo.Api part.


---After completing the mapping, there will be some changes about this api.

use Result.cs for Application layer. With this way you can map them easily.


After connecting to the database, connect redis for storing jwt token.


Lets sort:

Dapper https://github.com/SyncfusionExamples/ASP.NET-Core-Web-API-with-Dapper-and-PostgreSQL/blob/master/DotNetCRUD/Services/EmployeeService.cs
Redis -> fr Docker.
Unit tests https://www.youtube.com/watch?v=adaQ52DMitE
Kubernetes + Docker + Redis +  MSSQL
FluentEmail.
SMS system.
Azure.


Later gonna add fastApiEndpoints 

-------------------

Change sql commands

Add If-Else statements


Dapper !! -> https://code-maze.com/dapper-migrations-fluentmigrator-aspnetcore/ Dapper Migration.

Example code:
```csharp
public async Task<ErrorOr<UserResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
{
    await Task.CompletedTask;

    var user = await _userRepository.GetUserByEmail(query.Email);

    if (user == null)
    {
        throw new Exception("User not found");
    }

    // Instead of comparing passwords, check if the token matches the one in Redis
    var storedToken = await _redisService.GetTokenAsync(user.Id);
    if (storedToken != query.Token) // Replace with actual Redis key and value retrieval logic
    {
        return Errors.Authentication.InvalidCredentials;
    }

    var token = _jwtTokenGenerator.GenerateToken(user);

    return new UserResult(user, token);
}



```

Check your notes in the Kommunity Notepad. 

LMAO Remember to change neovim's repository. You literally tried to push your own in Neovim's repository. Self note.


Create the mdf file, include it into your workspace. 