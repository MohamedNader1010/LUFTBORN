using LUFTBORN.Application.Common.Interfaces;

namespace LUFTBORN.Infrastructure.Services;

public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
