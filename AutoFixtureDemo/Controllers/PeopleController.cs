using AutoFixtureDemo.Dto;
using AutoFixtureDemo.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace AutoFixtureDemo.Controllers;

public class PeopleController : Controller
{
    private readonly IPeopleService _peopleService;

    public PeopleController(IPeopleService peopleService)
    {
        _peopleService = peopleService;
    }

    [HttpPost]
    public Task AddPersonAsync([FromBody] Person person, CancellationToken cancellationToken)
    {
        
        return _peopleService.AddPersonAsync(person, cancellationToken);
    }

    [HttpGet]
    public Task<Person> GetPersonAsync(string nationalId, CancellationToken cancellationToken)
    {
        return _peopleService.GetPersonAsync(nationalId, cancellationToken);
    }
}