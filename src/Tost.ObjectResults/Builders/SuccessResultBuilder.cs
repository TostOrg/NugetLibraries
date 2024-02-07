using Tost.CollectionsExtensions;
using Tost.ObjectResults.Interfaces;
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

    public static SuccessDetails ToSuccessDetails(this SuccessResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        var messages = result.Reasons.FindAll(p => p is not IPredefinedReason);

        var successDetails = new SuccessDetails();

        foreach (var message in messages)
        {
            successDetails.Extensions.Add(message.GetType().Name, message);
        }

        return successDetails;
    }

    public static SuccessDetails ToSuccessDetails<T>(this SuccessResult<T> result)
    {
        ArgumentNullException.ThrowIfNull(result);

        var valueObj = result.Reasons.Find(p => p is ValueResult<T>) as ValueResult<T>;

        ArgumentNullException.ThrowIfNull(valueObj);

        var messages = result.Reasons.FindAll(p => p is not IPredefinedReason);

        var successDetails = new SuccessDetails<T>
        {
            Value = valueObj.Value
        };

        foreach (var message in messages)
        {
            successDetails.Extensions.Add(message.GetType().Name, message);
        }

        return successDetails;
    }
}
