using AutoFixture;
using AutoFixtureDemo.Entities;
using AutoFixtureDemo.Services;
using AutoFixtureDemo.Services.Abstraction;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;

namespace AutoFixtureDemo.Unit.Test;

public class PeopleServiceTests
{
    private readonly ITestOutputHelper _outputHelper;
    private readonly IPeopleService _sut;
    private readonly IPeopleRepository _peopleRepository;

    public PeopleServiceTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        var logger = Substitute.For<ILogger<PeopleService>>();
        _peopleRepository = Substitute.For<IPeopleRepository>();

        _sut = new PeopleService(logger, _peopleRepository);
    }

    [Fact]
    public async Task GetPersonAsync_ShouldReturnThePerson_WhenThePersonExists()
    {
        // Arrange
        var fixture = new Fixture();
        var person = fixture.Create<Person>();
        
        _peopleRepository.GetPersonAsync("1", Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(person));
        
        // Act
        var actual = await _sut.GetPersonAsync("1", CancellationToken.None);

        // Assert
        actual.NationalId.Should().Be(person.Id);
        actual.FirstName.Should().Be(person.FirstName);
        actual.LastName.Should().Be(person.LastName);
        
        
        _outputHelper.WriteLine($"ID: {person.Id} FirstName: {person.FirstName} LastName: {person.LastName}");
    }
}