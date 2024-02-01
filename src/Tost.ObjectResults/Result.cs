using Microsoft.VisualBasic;

using System.Collections;
using System.Collections.ObjectModel;

using Tost.CollectionsExtensions;
using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults;

public class Result : IFailedResult, ISucceededResult
{
    public bool IsFailed => Reasons.Find(p => p is IError) is not null;

    public bool IsSuccess => !IsFailed;

    public Collection<IReason> Reasons { get; } = [];

    public Collection<IError> Errors => Reasons.FindAll(p => p is IError).ConvertAll(p => (p as IError)!);

    public Collection<ISuccess> Successes => Reasons.FindAll(p => p is ISuccess).ConvertAll(p => (p as ISuccess)!);

    public static Result Ok()
    {
        return new Result();
    }

    public static ISucceededResult<T> Ok<T>(T value)
    {
        var result = new Result<T>();
        return result.WithValue(value);
    }

    public static IFailedResult Fail()
    {
        return new Result();
    }
}

public class Result<T> : Result, ISucceededResult<T>
{
    private T _value = default!;

    public T? ValueOrDefault => _value;

    public T Value
    {
        get
        {
            ArgumentNullException.ThrowIfNull(_value, nameof(Value));
            ThrowIfFailed();
            return _value;
        }
        private set
        {
            ThrowIfFailed();
            _value = value;
        }
    }

    public ISucceededResult<T> WithValue(T value)
    {
        Value = value;
        return this;
    }

    private void ThrowIfFailed()
    {
        if (IsFailed)
        {
            throw new InvalidOperationException("Result is in status failed. Value is not set. Having: " + ReasonFormat.ErrorReasonsToString(Errors));
        }
    }
}

internal static class ReasonFormat
{
    public static string ErrorReasonsToString(IReadOnlyCollection<IError> errorReasons)
    {
        return string.Join("; ", errorReasons);
    }

    public static string ReasonsToString(IReadOnlyCollection<IReason> errorReasons)
    {
        return string.Join("; ", errorReasons);
    }
}
