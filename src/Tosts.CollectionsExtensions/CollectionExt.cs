using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Tost.CollectionsExtensions;

public static class CollectionExt
{
    public static Collection<T> FindAll<T>(this Collection<T> collection, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(predicate);

        var list = new List<T>(collection.Count);

        var counter = 0;
        for (var i = 0; i < collection.Count; i++)
        {
            if (predicate(collection[i]) is false)
            {
                continue;
            }

            list.Add(collection[i]);
            counter++;
        }

        CollectionsMarshal.SetCount(list, counter);

        return new Collection<T>(list);
    }

    public static Collection<TOutput> ConvertAll<TInput, TOutput>(this Collection<TInput> collection, Converter<TInput, TOutput> converter)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(converter);

        var list = new List<TOutput>(collection.Count);

        for (int i = 0; i < collection.Count; i++)
        {
            list[i] = converter(collection[i]);
        }

        return new Collection<TOutput>(list);
    }

    public static T? Find<T>(this Collection<T> collection, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(predicate);

        for (int i = 0; i < collection.Count; i++)
        {
            if (predicate(collection[i]) is false)
            {
                continue;
            }

            return collection[i];
        }

        return default;
    }
}
