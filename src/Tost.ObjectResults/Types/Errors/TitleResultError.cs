using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Errors;

public sealed record TitleResultError(string? Message) : IPredefinedReason, IError;
