namespace Tost.ObjectResults.Interfaces;

public interface IError : IReason
{
    public string? Message { get; init; }
}
