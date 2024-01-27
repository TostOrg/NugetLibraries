using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types;

internal record TitleResultError(string? Message) : IError;
