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

[Route("api/[controller]")]
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

    //[HttpPost("refresh")]
    //public async Task<IActionResult> Refresh(RefreshTokenRequest request)
    //{
    //    var command = _mapper.Map<RefreshTokenCommand>(request);
    //    ErrorOr<AuthenticationResult> refreshResult = await _mediator.Send(command);
    //    return refreshResult.Match(
    //        refreshResult => Ok(_mapper.Map<AuthenticationResponse>(refreshResult)),
    //        error => Problem(error)
    //    );
    //}


    //[HttpPost("revoke")]
    //public async Task<IActionResult> Revoke(RevokeTokenRequest request)
    //{
    //    var command = _mapper.Map<RevokeTokenCommand>(request);
    //    ErrorOr<AuthenticationResult> revokeResult = await _mediator.Send(command);
    //    return revokeResult.Match(
    //        revokeResult => Ok(_mapper.Map<AuthenticationResponse>(revokeResult)),
    //        error => Problem(error)
    //    );
    //}

    //[HttpPost("verify")]
    //public async Task<IActionResult> Verify(VerifyTokenRequest request)
    //{
    //    var query = _mapper.Map<VerifyTokenQuery>(request);
    //    ErrorOr<AuthenticationResult> verifyResult = await _mediator.Send(query);
    //    return verifyResult.Match(
    //        verifyResult => Ok(_mapper.Map<AuthenticationResponse>(verifyResult)),
    //        error => Problem(error)
    //    );
    //}

    //[HttpPost("forgot-password")]
    //public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
    //{
    //    var query = _mapper.Map<ForgotPasswordQuery>(request);
    //    ErrorOr<AuthenticationResult> forgotPasswordResult = await _mediator.Send(query);
    //    return forgotPasswordResult.Match(
    //        forgotPasswordResult => Ok(_mapper.Map<AuthenticationResponse>(forgotPasswordResult)),
    //        error => Problem(error)
    //    );
    //}

    //[HttpPost("reset-password")]
    //public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
    //{
    //    var command = _mapper.Map<ResetPasswordCommand>(request);
    //    ErrorOr<AuthenticationResult> resetPasswordResult = await _mediator.Send(command);
    //    return resetPasswordResult.Match(
    //        resetPasswordResult => Ok(_mapper.Map<AuthenticationResponse>(resetPasswordResult)),
    //        error => Problem(error)
    //    );
    //}

    //[HttpPost("verify-email")]
    //public async Task<IActionResult> VerifyEmail(VerifyEmailRequest request)
    //{
    //    var command = _mapper.Map<VerifyEmailCommand>(request);
    //    ErrorOr<AuthenticationResult> verifyEmailResult = await _mediator.Send(command);
    //    return verifyEmailResult.Match(
    //        verifyEmailResult => Ok(_mapper.Map<AuthenticationResponse>(verifyEmailResult)),
    //        error => Problem(error)
    //    );
    //}

    //[HttpPost("validate-reset-token")]

    //public async Task<IActionResult> ValidateResetToken(ValidateResetTokenRequest request)
    //{
    //    var query = _mapper.Map<ValidateResetTokenQuery>(query);
    //    ErrorOr<AuthenticationResult> validateResetTokenResult = await _mediator.Send(query);
    //    return validateResetTokenResult.Match(
    //        validateResetTokenResult => Ok(_mapper.Map<AuthenticationResponse>(validateResetTokenResult)),
    //        error => Problem(error)
    //    );
    //}

    //[HttpGet("users")]
    //public async Task<IActionResult> GetAll()
    //{
    //    var query = _mapper.Map<GetAllUsersQuery>(new ç());
    //    ErrorOr<IEnumerable<AuthenticationResult>> getAllUsersResult = await _mediator.Send(query);
    //    return getAllUsersResult.Match(
    //        getAllUsersResult => Ok(_mapper.Map<IEnumerable<UserResponse>>(getAllUsersResult)),
    //        error => Problem(error)
    //    );
    //}

    //[HttpGet("users/{id}")]
    //public async Task<IActionResult> GetById(Guid id)
    //{
    //    var query = _mapper.Map<GetUserByIdQuery>(new GetUserByIdRequest { Id = id });
    //    ErrorOr<AuthenticationResult> getUserByIdResult = await _mediator.Send(query);
    //    return getUserByIdResult.Match(
    //        getUserByIdResult => Ok(_mapper.Map<UserResponse>(getUserByIdResult)),
    //        error => Problem(error)
    //    );
    //}



    //[HttpDelete("users/{id}")]
    //public async Task<IActionResult> Delete(Guid id)
    //{
    //    var command = _mapper.Map<DeleteUserCommand>(new DeleteUserRequest { Id = id });
    //    ErrorOr<AuthenticationResult> deleteUserResult = await _mediator.Send(command);
    //    return deleteUserResult.Match(
    //        deleteUserResult => Ok(_mapper.Map<UserResponse>(deleteUserResult)),
    //        error => Problem(error)
    //    );
    //}







}
