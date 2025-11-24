using Bunit;
using FluentAssertions;

namespace Portal.Blazor.UnitTests;

public class BunitDemoTests : Bunit.TestContext
{
    [Fact]
    public void BUnit_Should_BeAvailable_And_TestContext_Should_Work()
    {
        // Arrange & Act - This proves bUnit is installed and working
        var services = Services;

        // Assert - Using FluentAssertions
        services.Should().NotBeNull("because bUnit's TestContext provides a service collection");
    }

    [Fact]
    public void FluentAssertions_Should_BeAvailable()
    {
        // Arrange
        var testFrameworks = new List<string> { "xUnit", "bUnit", "FluentAssertions" };

        // Act & Assert - Using FluentAssertions
        testFrameworks.Should().Contain("bUnit")
            .And.HaveCount(3)
            .And.ContainInOrder("xUnit", "bUnit", "FluentAssertions");
    }
}

