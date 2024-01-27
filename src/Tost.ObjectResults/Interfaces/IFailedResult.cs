namespace Tost.ObjectResults.Interfaces;

public interface IFailedResult
{
    public List<IReason> Reasons { get; }
    public List<IError> Errors { get; }
}
