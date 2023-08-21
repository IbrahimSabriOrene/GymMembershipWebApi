using ErrorOr;
using MediatR;
using MemberInfo.Application.Authentication.Common;

namespace MemberInfo.Application.Authentication.Queries.Login;

public record LoginQuery
(
    string Email,
    string Password
): IRequest<ErrorOr<AuthenticationResult>>;
