using FluentAssertions;

namespace Tost.ObjectResult.Tests;

public class TestExample
{
    [Fact]
    public void Test()
    {
        true.Should().BeTrue();
    }
}
