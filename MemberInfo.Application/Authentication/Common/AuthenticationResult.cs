using Customer.Domain.Entities;

namespace Customer.Application.Authentication.Common;

public record CustomerResult(
    User User,
    string Token);
