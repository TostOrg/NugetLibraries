using System.Collections.ObjectModel;

namespace Tost.ObjectResults.Interfaces;

public interface IFailedResult : IResult
{
    public ReadOnlyCollection<IError> Errors { get; }
}
