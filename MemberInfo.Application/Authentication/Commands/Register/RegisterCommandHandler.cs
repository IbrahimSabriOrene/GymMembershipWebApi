using ErrorOr;
using MediatR;
using Customer.Application.Authentication.Common;
using Customer.Domain.Common.Errors;
using Customer.Domain.Common.Interfaces.Authentication;
using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Entities;

namespace Customer.Application.Authentication.Commands.Register;

using BC = BCrypt.Net.BCrypt;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    /// <summary>
    ///  TODO:
    /// 1. Check if email is valid
    /// 2. Hash password
    /// 3. Create user 
    /// 4. Generate token
    /// 5. Store token in redis
    /// 6. Return token and user
    /// 7. Check if token matches users token in redis
    /// 8. Return user
    /// 9. Return error if something fails
    /// 10. Return error if user already exists
    /// 11. Return error if user was not created
    /// 12. Return error if token was not generated
    /// 13. Return error if token was not stored in redis
    /// 14. Return error if token does not match users token in redis
    /// 15. Return error if user was not found
    /// 16. Return error if password does not match
    /// </summary>

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)

    {
        await Task.CompletedTask;

        string salt = BC.GenerateSalt(12);

        var hashedPassword = BC.HashPassword(command.Password, salt);

        if (_userRepository.IsUserExists(command.Email).Result == true)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            PasswordHash = hashedPassword
        };

        var token = _jwtTokenGenerator.GenerateToken(user);
        user.Token = token;

        await _userRepository.CreateUser(user); 



        var userResult = new AuthenticationResult(
            user,
            hashedPassword,
            token);

        return userResult;
    }
}
