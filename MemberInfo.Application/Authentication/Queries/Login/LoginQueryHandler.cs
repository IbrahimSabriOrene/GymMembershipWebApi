using ErrorOr;
using MediatR;
using Customer.Application.Authentication.Common;
using Customer.Domain.Common.Errors;
using Customer.Domain.Common.Interfaces.Authentication;
using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Entities;

namespace Customer.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<UserResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var userIsValid = _userRepository.IsEmailValid(query.Email).Result switch
        {
            true => _userRepository.IsEmailValid(query.Email).Result,
            _ => throw new Exception("User not found")
        };
        
        User user = _userRepository.GetUserByEmail(query.Email).Result;
        var token = _jwtTokenGenerator.GenerateToken(user);
        if (user.Token != query.Password) // TODO: Hash password
        {
            return Errors.Authentication.InvalidCredentials;
        }
        // TODO: Store token in redis.

        // TODO: Return token and user.

        // Check if token matches users token in redis.


        return new UserResult(
            user,
            token);
    }


}

