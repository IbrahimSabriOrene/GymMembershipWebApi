using MemberInfo.Domain.Entities;

namespace MemberInfo.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
