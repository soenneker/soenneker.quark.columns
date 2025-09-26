using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Quark.Columns.Tests;

[Collection("Collection")]
public sealed class ColumnTests : FixturedUnitTest
{
    public ColumnTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {
        // Column is now a Razor component, so integration tests would be more appropriate
        // This test serves as a placeholder for future component testing
    }
}
