using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Domain.Entities;


namespace Customer.Domain.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<bool> IsEmailValid(string email);
    Task <User> GetUserByEmail(string email);
    Task<bool> CreateUser(User user);
    Task<bool> DeleteUser(Guid id);
    Task<bool> ChangeFirstName(User user);
    Task<bool> ChangeLastName(User user);
    Task<bool> ChangeEmail(User user);
    

    //Store token in redis.

}
