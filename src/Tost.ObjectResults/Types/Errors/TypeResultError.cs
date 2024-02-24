using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Errors;

public sealed record TypeResultError(string? Message) : IPredefinedReason, IError;
