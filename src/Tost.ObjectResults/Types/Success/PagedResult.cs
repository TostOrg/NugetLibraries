using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Success;

public sealed record PagedResult(int PageNumber, int PageSize, int TotalCount) : ISuccess;
