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

    public static SuccessResult<T> WithStatusCode<T>(this SuccessResult<T> result, System.Net.HttpStatusCode statusCode)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(statusCode);

        result.Reasons.Add(new StatusCodeResult(statusCode));

        return result;
    }

    public static SuccessResult WithStatusCode(this SuccessResult result, System.Net.HttpStatusCode statusCode)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(statusCode);

        result.Reasons.Add(new StatusCodeResult(statusCode));

        return result;
    }
}
