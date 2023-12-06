using Customer.Domain.Entities;

namespace Customer.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string PasswordHash,
    string Token);



/*  New version of AuthenticationResult
public record AuthenticationResult(
        User User,
        string PasswordHash,
        string AccessToken,
        string RefreshToken,
        DateTime ExpiresIn,
        bool Success,
        string ErrorMessage
    );    
*/