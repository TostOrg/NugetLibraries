using System.Text.Json.Serialization;

namespace Tost.ObjectResults;

public record SuccessDetails
{
    [JsonExtensionData]
    public IDictionary<string, object?> Extensions { get; } = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
}

public record SuccessDetails<T> : SuccessDetails
{
    public required T Value { get; init; }
}
