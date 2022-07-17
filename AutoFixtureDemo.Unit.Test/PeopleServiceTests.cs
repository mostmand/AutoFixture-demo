using AutoFixtureDemo.Entities;
using AutoFixtureDemo.Services;
using AutoFixtureDemo.Services.Abstraction;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace AutoFixtureDemo.Unit.Test;

public class PeopleServiceTests
{
    private readonly IPeopleService _sut;
    private readonly IPeopleRepository _peopleRepository;

    public PeopleServiceTests()
    {
        var logger = Substitute.For<ILogger<PeopleService>>();
        _peopleRepository = Substitute.For<IPeopleRepository>();

        _sut = new PeopleService(logger, _peopleRepository);
    }

    [Fact]
    public async Task GetPersonAsync_ShouldReturnThePerson_WhenThePersonExists()
    {
        // Arrange
        var person = new Person("1", "Asghar", "Asghari");
        
        _peopleRepository.GetPersonAsync("1", Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(person));
        
        // Act
        var actual = await _sut.GetPersonAsync("1", CancellationToken.None);

        // Assert
        actual.NationalId.Should().Be(person.Id);
        actual.FirstName.Should().Be(person.FirstName);
        actual.LastName.Should().Be(person.LastName);
    }
}