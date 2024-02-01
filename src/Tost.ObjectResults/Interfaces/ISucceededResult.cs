using System.Collections.ObjectModel;

namespace Tost.ObjectResults.Interfaces;

public interface ISucceededResult
{
    public Collection<IReason> Reasons { get; }
    public Collection<ISuccess> Successes { get; }
}

public interface ISucceededResult<T> : ISucceededResult
{
    public T Value { get; }
    public T? ValueOrDefault { get; }
}
