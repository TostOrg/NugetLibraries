using System.Collections.ObjectModel;

namespace Tost.ObjectResults.Interfaces;

public interface IFailedResult
{
    public Collection<IReason> Reasons { get; }
    public Collection<IError> Errors { get; }
}
