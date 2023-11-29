using Customer.Domain.Entities;

namespace Customer.Application.Authentication.Common;

public record UserResult(
    User User,
    string Token);
