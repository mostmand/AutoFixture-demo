using AutoFixtureDemo.Entities;

namespace AutoFixtureDemo.Services.Abstraction;

public interface IPeopleRepository
{
    Task AddPersonAsync(Person person, CancellationToken cancellationToken);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="nationalId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    Task<Person> GetPersonAsync(string nationalId, CancellationToken cancellationToken);
}