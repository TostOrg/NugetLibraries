using Tost.ObjectResults.ResultObjects;
using Tost.ObjectResults.Types.Success;

namespace Tost.ObjectResults.Builders;

public static class SuccessResultBuilder
{
    public static SuccessResult<T> WithPagedData<T>(this SuccessResult<T> result, int page, int pageSize, int totalCount)
    {
        ArgumentNullException.ThrowIfNull(result);

        result.Reasons.Add(new PagedResult(page, pageSize, totalCount));

        return result;
    }
}
