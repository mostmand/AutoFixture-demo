namespace AutoFixtureDemo.Services.Abstraction;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}