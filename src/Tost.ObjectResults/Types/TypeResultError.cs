using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types;

internal record TypeResultError(string? Message) : IError;
