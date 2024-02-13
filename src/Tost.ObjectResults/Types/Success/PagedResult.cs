using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Success;

internal sealed record PagedResult(int PageNumber, int PageSize, int TotalCount) : ISuccess;
