using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberInfo.Application.Authentication.Common;

public record TokenResult(
    string Token,
    DateTime Expires,
    string RefreshToken,
    DateTime RefreshTokenExpires);