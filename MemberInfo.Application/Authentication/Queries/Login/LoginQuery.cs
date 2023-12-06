using ErrorOr;
using MediatR;
using Customer.Application.Authentication.Common;

namespace Customer.Application.Authentication.Queries.Login;

public record LoginQuery
(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
