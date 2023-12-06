using ErrorOr;
using MediatR;
using Customer.Application.Authentication.Common;
using Customer.Domain.Common.Errors;
using Customer.Domain.Common.Interfaces.Authentication;
using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Entities;

namespace Customer.Application.Authentication.Queries.Login;

using BC = BCrypt.Net.BCrypt;
public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var userIsValid = _userRepository.IsUserExists(query.Email).Result;

        if (!userIsValid)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        User user = _userRepository.GetUserByEmail(query.Email).Result;
        var hashedPassword = user.PasswordHash;
        var verifyPassword = BC.Verify(query.Password, hashedPassword);
        if (!verifyPassword)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        var token = _jwtTokenGenerator.GenerateToken(user);
       // if (user.Token != query.Password) // TODO: Hash password
       // {
       //     return Errors.Authentication.InvalidCredentials;
       // }
        // TODO: Store token in redis.

        // TODO: Return token and user.

        // Check if token matches users token in redis.


        return new AuthenticationResult(
            user,
            hashedPassword,
            token);
    }


}

