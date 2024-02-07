using System.Collections.ObjectModel;

namespace Tost.ObjectResults.Interfaces;

public interface IResult
{
    public Collection<IReason> Reasons { get; }
    public bool IsFailed { get; }
    public bool IsSuccess { get; }
}
