using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Errors;

internal sealed record TypeResultError(string? Message) : IPredefinedReason, IError;
