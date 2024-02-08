using FluentAssertions.Execution;

using Tost.ObjectResults;
using Tost.ObjectResults.Builders;
using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResult.Tests;

public class ProblemDetailsTests
{
    [Fact]
    public void ProblemDetailsShouldSetHttpStatusCode()
    {
        var resultObject = Result.Fail().WithHttpStatusCode(System.Net.HttpStatusCode.Unauthorized);

        var problemDetails = resultObject.ToProblemDetails();

        problemDetails.Should().BeOfType<ProblemDetails>().Which.Status.Should().Be((int)System.Net.HttpStatusCode.Unauthorized);
    }

    [Fact]
    public void ProblemDetailsShouldSetTestError()
    {
        const int count = 123;
        const string message = "test";

        var testError = new TestError(count, message);
        var resultObject = Result.Fail().WithError(testError);

        var problemDetails = resultObject.ToProblemDetails();
        var error = problemDetails.Extensions.First(p => p.Key == nameof(TestError));

        using (new AssertionScope())
        {
            problemDetails.Should().BeOfType<ProblemDetails>();
            error.Value.Should().BeOfType<TestError>().Which.Count.Should().Be(count);
            error.Value.Should().BeOfType<TestError>().Which.Message.Should().Be(message);
        }
    }
}

public record TestError(int? Count, string? Message) : IError;
