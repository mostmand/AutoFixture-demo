using AutoFixtureDemo.Data.Abstraction;
using AutoFixtureDemo.Entities;
using AutoFixtureDemo.Services.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace AutoFixtureDemo.Services;

public class PeopleRepository : IPeopleRepository
{
    private readonly IPeopleContext _peopleContext;

    public PeopleRepository(IPeopleContext peopleContext)
    {
        _peopleContext = peopleContext ?? throw new ArgumentNullException(nameof(peopleContext));
    }

    public async Task AddPersonAsync(Person person, CancellationToken cancellationToken)
    {
        _peopleContext.People.Add(person);
        await _peopleContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Person> GetPersonAsync(string nationalId, CancellationToken cancellationToken)
    {
        var person = await _peopleContext.People.FirstOrDefaultAsync(person => person.Id == nationalId, cancellationToken);
        if (person is null)
        {
            throw new KeyNotFoundException($"No person with ID {nationalId} found");
        }

        return person;
    }
}