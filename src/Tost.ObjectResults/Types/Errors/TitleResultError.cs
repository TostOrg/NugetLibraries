using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Errors;

internal sealed record TitleResultError(string? Message) : IPredefinedReason, IError;
