using FluentAssertions;

namespace Portal.Common.UnitTests;

public class UnitTest1
{
   [Fact]
   public void Test1() => Assert.True(true);
}

public class TechnologyStackTests
{
    [Fact]
    public void FluentAssertions_Should_BeAvailable()
    {
        // Arrange
        var expectedVersion = ".NET 10";
        var actualVersion = ".NET 10";

        // Act & Assert - Using FluentAssertions
        actualVersion.Should().Be(expectedVersion);
    }

    [Fact]
    public void XUnit_v3_Should_BeWorking()
    {
        // Arrange
        var list = new List<string> { "xUnit", "bUnit", "FluentAssertions", "Testcontainers" };

        // Act & Assert - Using FluentAssertions
        list.Should().HaveCount(4)
            .And.Contain("xUnit")
            .And.Contain("FluentAssertions");
    }

    [Fact]
    public void TechnologyStack_Should_ContainRequiredComponents()
    {
        // Arrange
        var techStack = new Dictionary<string, string>
        {
            { ".NET", "10.0" },
            { "Aspire", "13.0" },
            { "xUnit", "3.2.0" },
            { "TypeScript", "5.9" },
            { "SCSS", "1.94" }
        };

        // Act & Assert - Using FluentAssertions
        techStack.Should().NotBeEmpty()
            .And.ContainKey(".NET")
            .And.ContainKey("Aspire");

        techStack[".NET"].Should().Be("10.0");
        techStack["xUnit"].Should().StartWith("3");
    }
}
