using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Errors;

public sealed record ReasonResultError(string? Message, string TypeName) : IPredefinedReason, IError;
