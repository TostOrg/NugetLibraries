using System.Collections.ObjectModel;

namespace Tost.ObjectResults.Interfaces;

public interface ISucceededResult : IResult
{
    public ReadOnlyCollection<ISuccess> Successes { get; }
}

public interface ISucceededResult<T> : ISucceededResult
{
    public T Value { get; }
}
