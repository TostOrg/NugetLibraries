using System.Collections.ObjectModel;

using Tost.CollectionsExtensions;
using Tost.ObjectResults.Interfaces;
using Tost.ObjectResults.Types.Success;

namespace Tost.ObjectResults.ResultObjects;

public class SuccessResult : Result, ISucceededResult
{
    internal SuccessResult()
    {
    }

    internal SuccessResult(Collection<IReason> reasons) : base(reasons)
    {
    }

    public ReadOnlyCollection<ISuccess> Successes => Reasons.FindAll(p => p is ISuccess).ConvertAll(p => (p as ISuccess)!).AsReadOnly();

    public SuccessResult<T> WithValue<T>(T value)
    {
        return new SuccessResult<T>(value, Reasons);
    }
}

public class SuccessResult<T> : SuccessResult, ISucceededResult<T>
{
    internal SuccessResult(T value)
    {
        Reasons.Add(new ValueResult<T>(value));
        Value = (Reasons.Find(p => p is ValueResult<int>) as ValueResult<T>)!.Value;
    }

    internal SuccessResult(T value, Collection<IReason> reasons) : base(reasons)
    {
        Reasons.Add(new ValueResult<T>(value));
        Value = (Reasons.Find(p => p is ValueResult<int>) as ValueResult<T>)!.Value;
    }

    public T Value { get; }
}
