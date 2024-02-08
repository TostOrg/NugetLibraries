using System.Collections.ObjectModel;

using Tost.CollectionsExtensions;
using Tost.ObjectResults.Interfaces;
using Tost.ObjectResults.ResultObjects;

namespace Tost.ObjectResults;

public class Result : IResult
{
    internal Result()
    {
        Reasons = [];
    }

    internal Result(Collection<IReason> reasons)
    {
        Reasons = reasons;
    }

    public bool IsFailed => Reasons.Exists(p => p is IError);

    public bool IsSuccess => !IsFailed;

    public Collection<IReason> Reasons { get; }

    public static SuccessResult Ok()
    {
        return new SuccessResult();
    }

    public static SuccessResult<T> Ok<T>(T value)
    {
        return new SuccessResult<T>(value);
    }

    public static FailureResult Fail()
    {
        return new FailureResult();
    }
}
