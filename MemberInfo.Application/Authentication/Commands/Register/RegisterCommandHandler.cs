using ErrorOr;
using MediatR;
using Customer.Application.Authentication.Common;
using Customer.Domain.Common.Errors;
using Customer.Domain.Common.Interfaces.Authentication;
using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Entities;

namespace Customer.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<UserResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }


    public async Task<ErrorOr<UserResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.IsEmailValid(command.Email) is  null)
        {
            return Errors.User.DuplicateEmail;
        }
    
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email
        };
        var token = _jwtTokenGenerator.GenerateToken(user);
        user.Token = token;

        var result = await _userRepository.CreateUser(user); //need adjustments -> this is bool so it will return true or false
        
        if (result is false)
        {
            throw new InvalidOperationException("User was not created."); // TODO: Create custom exception. and fix this
        }
       

        var userResult = new UserResult(
            user,
            token);

        return userResult;
    }
}
