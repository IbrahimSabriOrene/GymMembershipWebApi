using MemberInfo.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using MemberInfo.Application.Authentication.Commands.Register;
using MemberInfo.Application.Authentication.Common;
using MemberInfo.Application.Authentication.Queries.Login;
using MapsterMapper;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;

namespace MemberInfo.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

        return registerResult.Match(
            registerResult => Ok(_mapper.Map<AuthenticationResponse>(registerResult)),
            error => Problem(error)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(query);
        return loginResult.Match(
            loginResult => Ok(_mapper.Map<AuthenticationResponse>(loginResult)),
            error => Problem(error)
        );

    }



}
