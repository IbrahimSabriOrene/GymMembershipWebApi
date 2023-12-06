using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Domain.Entities;


namespace Customer.Domain.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<bool> IsUserExists(string email);
    Task <User> GetUserByEmail(string email);
    Task CreateUser(User user);
    Task<int> DeleteUser(Guid id);

    //Store token in redis.

}
