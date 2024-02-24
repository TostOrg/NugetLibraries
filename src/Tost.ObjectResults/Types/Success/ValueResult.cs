using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Success;

public sealed record ValueResult<T>(T Value) : IPredefinedReason, ISuccess;
