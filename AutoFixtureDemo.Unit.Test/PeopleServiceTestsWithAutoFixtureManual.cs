using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixtureDemo.Entities;
using AutoFixtureDemo.Services;
using AutoFixtureDemo.Services.Abstraction;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AutoFixtureDemo.Unit.Test;

public class PeopleServiceTestsWithAutoFixtureManual
{

    [Fact]
    public async Task GetPersonAsync_ShouldReturnThePerson_WhenThePersonExists()
    {
        // Arrange
        var fixture = new Fixture();
        fixture.Customize(new AutoNSubstituteCustomization());
        var peopleRepository = fixture.Freeze<IPeopleRepository>();
        var person = fixture.Create<Person>();
        
        peopleRepository.GetPersonAsync(person.Id, Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(person));
        var sut = fixture.Create<PeopleService>();
        
        // Act
        var actual = await sut.GetPersonAsync(person.Id, CancellationToken.None);

        // Assert
        actual.NationalId.Should().Be(person.Id);
        actual.FirstName.Should().Be(person.FirstName);
        actual.LastName.Should().Be(person.LastName);
    }
}