using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using MemberInfo.Application.Authentication.Common;

namespace MemberInfo.Application.Authentication.Commands.Register;

public record RegisterCommand
(
    string Email,
    string Password,
    string FirstName,
    string LastName
) : IRequest<ErrorOr<AuthenticationResult>>;
