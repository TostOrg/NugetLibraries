using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types;

internal record ReasonResultError(string? Message) : IError;
