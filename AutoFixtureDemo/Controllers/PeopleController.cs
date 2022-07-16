using AutoFixtureDemo.Dto;
using AutoFixtureDemo.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace AutoFixtureDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
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
    public async Task<IActionResult> GetPersonAsync(string nationalId, CancellationToken cancellationToken)
    {
        try
        {
            return new OkObjectResult(await _peopleService.GetPersonAsync(nationalId, cancellationToken));
        }
        catch (KeyNotFoundException)
        {
            return new NotFoundObjectResult($"No person found with ID {nationalId}");
        }

    }
}