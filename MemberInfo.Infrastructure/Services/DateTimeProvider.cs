using MemberInfo.Domain.Common.Interfaces.Services;

namespace MemberInfo.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
