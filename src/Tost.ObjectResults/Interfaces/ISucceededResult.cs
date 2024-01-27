namespace Tost.ObjectResults.Interfaces;

public interface ISucceededResult
{
    public List<IReason> Reasons { get; }
    public List<ISuccess> Successes { get; }
}

public interface ISucceededResult<T> : ISucceededResult
{
    public T Value { get; }
    public T? ValueOrDefault { get; }
}
