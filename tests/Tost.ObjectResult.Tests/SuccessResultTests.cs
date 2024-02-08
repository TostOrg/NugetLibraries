using Tost.ObjectResults;
using Tost.ObjectResults.ResultObjects;

namespace Tost.ObjectResult.Tests;

public class SuccessResultTests
{
    [Fact]
    public void ResultOkShouldReturnTypedSuccessResult()
    {
        const int value = 123;
        var okResult = Result.Ok(value);

        okResult.Should().BeOfType<SuccessResult<int>>().Which.Value.Should().Be(value);
    }
}
