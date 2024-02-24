using System.Net;
using System.Text.Json.Serialization;
using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Errors;

public sealed record HttpStatusCodeResultError(HttpStatusCode StatusCode) : IPredefinedReason, IError
{
    [JsonIgnore]
    public string? Message { get; init; }
}
