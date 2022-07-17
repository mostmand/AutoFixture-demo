using AutoFixture;
using AutoFixture.Xunit2;
using AutoFixtureDemo.Entities;
using AutoFixtureDemo.Services;
using AutoFixtureDemo.Services.Abstraction;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;

namespace AutoFixtureDemo.Unit.Test;


public class PeopleServiceTestsWithAutoFixture
{
    [Theory, AutoNSubstituteData]
    public async Task GetPersonAsync_ShouldReturnThePerson_WhenThePersonExists([Frozen] IPeopleRepository peopleRepository,
        PeopleService sut,
        Person person)
    {
        // Arrange
        peopleRepository.GetPersonAsync(person.Id, Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(person));
        
        // Act
        var actual = await sut.GetPersonAsync(person.Id, CancellationToken.None);

        // Assert
        actual.NationalId.Should().Be(person.Id);
        actual.FirstName.Should().Be(person.FirstName);
        actual.LastName.Should().Be(person.LastName);
    }
}