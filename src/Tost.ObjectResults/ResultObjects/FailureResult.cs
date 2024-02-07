using System.Collections.ObjectModel;
using Tost.CollectionsExtensions;
using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.ResultObjects;

public class FailureResult : Result, IFailedResult
{
    internal FailureResult()
    {
    }

    public ReadOnlyCollection<IError> Errors => Reasons.FindAll(p => p is IError).ConvertAll(p => (p as IError)!).AsReadOnly();
}
