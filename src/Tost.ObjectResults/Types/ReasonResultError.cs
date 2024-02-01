using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types;

internal sealed record ReasonResultError(string? Message) : IError;
