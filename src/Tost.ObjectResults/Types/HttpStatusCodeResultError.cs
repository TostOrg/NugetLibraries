using System.Net;
using System.Text.Json.Serialization;

using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types;

internal sealed record HttpStatusCodeResultError(HttpStatusCode StatusCode) : IError
{
    [JsonIgnore]
    public string? Message { get; init; }
}
