using Customer.Domain.Common.Interfaces.Services;

namespace Customer.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
