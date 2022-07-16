using AutoFixtureDemo.Entities;

namespace AutoFixtureDemo.Services.Abstraction;

public interface IPeopleRepository
{
    Task AddPersonAsync(Person person, CancellationToken cancellationToken);
    Task<Person> GetPersonAsync(string nationalId, CancellationToken cancellationToken);
}