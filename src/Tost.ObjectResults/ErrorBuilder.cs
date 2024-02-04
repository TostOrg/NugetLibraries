using System.Text.Json;

using Tost.CollectionsExtensions;
using Tost.ObjectResults.Interfaces;
using Tost.ObjectResults.Types;

namespace Tost.ObjectResults;

public static class ErrorBuilder
{
    public static IFailedResult WithHttpStatusCode(this IFailedResult value, System.Net.HttpStatusCode statusCode)
    {
        if (!Constants.StatusCodeDefaults.TryGetValue((int)statusCode, out var statusCodeConstant))
        {
            _ = Constants.StatusCodeDefaults.TryGetValue((int)System.Net.HttpStatusCode.InternalServerError, out statusCodeConstant);
        }

        value.WithError(new TitleResultError(statusCodeConstant.Title));
        value.WithError(new TypeResultError(statusCodeConstant.Type));
        value.WithError(new HttpStatusCodeResultError(statusCode));

        return value;
    }

    public static IFailedResult WithReason(this IFailedResult value, string reason)
    {
        return value.WithError(new ReasonResultError(reason));
    }

    public static IFailedResult WithError(this IFailedResult result, IError error)
    {
        ArgumentNullException.ThrowIfNull(result);

        result.Reasons.Add(error);
        return result;
    }

    public static ProblemDetails ToProblemDetails(this Result result)
    {
        ArgumentNullException.ThrowIfNull(result);

        var detail = (result.Errors.Find(p => p is ReasonResultError) as ReasonResultError)?.Message ?? "Unknown";
        var statusCode = (int)((result.Errors.Find(p => p is HttpStatusCodeResultError) as HttpStatusCodeResultError)?.StatusCode ?? System.Net.HttpStatusCode.BadRequest);
        var title = (result.Errors.Find(p => p is TitleResultError) as TitleResultError)?.Message ?? "Unknown";
        var type = (result.Errors.Find(p => p is TypeResultError) as TypeResultError)?.Message ?? $"https://httpstatuses.com/{statusCode}";
        var messages = result.Reasons.FindAll(p => p.Message is not null).ConvertAll(p => p.Message);

        return new ProblemDetails
        {
            Detail = JsonSerializer.Serialize(messages),
            Status = statusCode,
            Title = title,
            Type = type
        };
    }
}
