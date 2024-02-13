using System.Text.Json;
using Tost.CollectionsExtensions;
using Tost.ObjectResults.Interfaces;
using Tost.ObjectResults.ResultObjects;
using Tost.ObjectResults.Types.Errors;

namespace Tost.ObjectResults.Builders;

public static class FailureResultBuilder
{
    public static FailureResult WithHttpStatusCode(this FailureResult result, System.Net.HttpStatusCode statusCode)
    {
        ArgumentNullException.ThrowIfNull(result);

        if (!Constants.StatusCodeDefaults.TryGetValue((int)statusCode, out var statusCodeConstant))
        {
            _ = Constants.StatusCodeDefaults.TryGetValue((int)System.Net.HttpStatusCode.InternalServerError, out statusCodeConstant);
        }

        result.WithError(new TitleResultError(statusCodeConstant.Title));
        result.WithError(new TypeResultError(statusCodeConstant.Type));
        result.WithError(new HttpStatusCodeResultError(statusCode));

        return result;
    }

    public static FailureResult WithReason(this FailureResult result, string reason)
    {
        return result.WithError(new ReasonResultError(reason, nameof(ReasonResultError)));
    }

    public static FailureResult WithError(this FailureResult result, IError error)
    {
        ArgumentNullException.ThrowIfNull(result);

        result.Reasons.Add(error);
        return result;
    }

    public static ProblemDetails ToProblemDetails(this FailureResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        var detail = (result.Errors.Find(p => p is ReasonResultError) as ReasonResultError)?.Message;
        var statusCode = (result.Errors.Find(p => p is HttpStatusCodeResultError) as HttpStatusCodeResultError)?.StatusCode;
        var title = (result.Errors.Find(p => p is TitleResultError) as TitleResultError)?.Message ?? "Unknown";
        var type = (result.Errors.Find(p => p is TypeResultError) as TypeResultError)?.Message;
        var messages = result.Reasons.FindAll(p => p is not IPredefinedReason);

        var problemDetail = new ProblemDetails
        {
            Detail = detail ?? title,
            Status = (int?)statusCode ?? (int)System.Net.HttpStatusCode.BadRequest,
            Title = title,
        };

        problemDetail.Type = type ?? $"https://httpstatuses.com/{problemDetail.Status}";

        foreach (var message in messages)
        {
            problemDetail.Extensions.Add(message.GetType().Name, message);
        }

        return problemDetail;
    }
}
