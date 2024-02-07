using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Success;

internal sealed record ValueResult<T>(T Value) : IPredefinedReason, ISuccess;
