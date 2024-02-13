using System.Collections.ObjectModel;
using Tost.CollectionsExtensions;
using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.ResultObjects;

public class FailureResult : IFailedResult
{
    internal FailureResult()
    {
        Reasons = [];
    }

    public ReadOnlyCollection<IError> Errors => Reasons.FindAll(p => p is IError).ConvertAll(p => (p as IError)!).AsReadOnly();

    public Collection<IReason> Reasons { get; }
    public bool IsFailed => Reasons.Exists(p => p is IError);

    public bool IsSuccess => !IsFailed;
}
