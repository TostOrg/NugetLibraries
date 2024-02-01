using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types;

internal sealed record TypeResultError(string? Message) : IError;
