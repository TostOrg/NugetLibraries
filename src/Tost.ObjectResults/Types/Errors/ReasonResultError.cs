using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Errors;

internal sealed record ReasonResultError(string? Message, string TypeName) : IPredefinedReason, IError;
