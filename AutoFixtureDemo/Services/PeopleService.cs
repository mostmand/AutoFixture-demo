using AutoFixtureDemo.Dto;
using AutoFixtureDemo.Services.Abstraction;

namespace AutoFixtureDemo.Services;

public class PeopleService : IPeopleService
{
    private readonly ILogger<PeopleService> _logger;
    private readonly IPeopleRepository _peopleRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public PeopleService(ILogger<PeopleService> logger, IPeopleRepository peopleRepository, IDateTimeProvider dateTimeProvider)
    {
        _logger = logger;
        _peopleRepository = peopleRepository;
        _dateTimeProvider = dateTimeProvider;
    }
    
    public Task AddPersonAsync(Person person, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Person with with national ID {NationalId} called {FirstName} {LastName} is going to be added",
            person.NationalId, person.FirstName, person.LastName);
        return _peopleRepository.AddPersonAsync(new Entities.Person(person.NationalId, person.FirstName, person.LastName), cancellationToken);
    }

    public async Task<Person> GetPersonAsync(string nationalId, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get person with with national ID {NationalId} requested", nationalId);
        var person = await _peopleRepository.GetPersonAsync(nationalId, cancellationToken);
        return new Person(person.Id, person.FirstName, person.LastName);
    }
}