using Customer.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Customer.Application.Authentication.Commands.Register;
using Customer.Application.Authentication.Common;
using Customer.Application.Authentication.Queries.Login;
using MapsterMapper;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;

namespace Customer.Api.Controllers;

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
        ErrorOr<CustomerResult> registerResult = await _mediator.Send(command);

        return registerResult.Match(
            registerResult => Ok(_mapper.Map<AuthenticationResponse>(registerResult)),
            error => Problem(error)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<CustomerResult> loginResult = await _mediator.Send(query);
        return loginResult.Match(
            loginResult => Ok(_mapper.Map<AuthenticationResponse>(loginResult)),
            error => Problem(error)
        );

    }



}
