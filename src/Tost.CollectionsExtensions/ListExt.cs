namespace Tost.CollectionsExtensions;

public static class ListExt
{
    public static List<T> FindAll<T>(this List<T> list, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(predicate);

        var counter = 0;
        var newList = new List<T>(list.Count);
        for (var i = 0; i < list.Count; i++)
        {
            if (predicate(list[i]) is false)
            {
                continue;
            }

            newList.Add(list[i]);
            counter++;
        }

        return newList;
    }
}
