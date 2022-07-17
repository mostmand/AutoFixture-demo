using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace AutoFixtureDemo.Unit.Test;

public class AutoNSubstituteDataAttribute : AutoDataAttribute
{
    public AutoNSubstituteDataAttribute()
        : base(() => new Fixture()
            .Customize(new AutoNSubstituteCustomization()))
    {
    }
}