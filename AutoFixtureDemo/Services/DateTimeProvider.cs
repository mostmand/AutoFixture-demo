using AutoFixtureDemo.Services.Abstraction;

namespace AutoFixtureDemo.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}