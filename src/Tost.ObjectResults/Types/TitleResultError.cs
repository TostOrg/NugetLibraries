using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types;

internal sealed record TitleResultError(string? Message) : IError;
