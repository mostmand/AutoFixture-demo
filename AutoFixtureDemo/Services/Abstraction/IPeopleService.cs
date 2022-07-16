using AutoFixtureDemo.Dto;

namespace AutoFixtureDemo.Services.Abstraction;

public interface IPeopleService
{
    Task AddPersonAsync(Person person, CancellationToken cancellationToken);
    Task<Person> GetPersonAsync(string nationalId, CancellationToken cancellationToken);
}