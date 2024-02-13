﻿using System.Collections.ObjectModel;

namespace Tost.CollectionsExtensions;

public static class ReadOnlyCollectionExt
{
    public static ReadOnlyCollection<T> FindAll<T>(this ReadOnlyCollection<T> collection, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(predicate);

        var counter = 0;
        var newList = new List<T>(collection.Count);
        for (var i = 0; i < collection.Count; i++)
        {
            if (predicate(collection[i]) is false)
            {
                continue;
            }

            newList.Add(collection[i]);
            counter++;
        }

        return new ReadOnlyCollection<T>(newList);
    }

    public static ReadOnlyCollection<TOutput> ConvertAll<TInput, TOutput>(this ReadOnlyCollection<TInput> collection, Converter<TInput, TOutput> converter)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(converter);

        var list = new List<TOutput>(collection.Count);

        for (int i = 0; i < collection.Count; i++)
        {
            list.Add(converter(collection[i]));
        }

        return new ReadOnlyCollection<TOutput>(list);
    }

    public static T? Find<T>(this ReadOnlyCollection<T> collection, Predicate<T> predicate)
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

    public static bool Exists<T>(this ReadOnlyCollection<T> collection, Predicate<T> predicate)
    {
        return collection.Find(predicate) is not null;
    }
}
