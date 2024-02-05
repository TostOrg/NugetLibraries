﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tost.CollectionsExtensions;

public static class CollectionExt
{
    public static Collection<T> FindAll<T>(this Collection<T> collection, Predicate<T> predicate)
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

        return new Collection<T>(newList);
    }

    public static Collection<TOutput> ConvertAll<TInput, TOutput>(this Collection<TInput> collection, Converter<TInput, TOutput> converter)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(converter);

        var list = new List<TOutput>(collection.Count);

        for (int i = 0; i < collection.Count; i++)
        {
            list.Add(converter(collection[i]));
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

    public static bool Exists<T>(this Collection<T> collection, Predicate<T> predicate)
    {
        return collection.Find(predicate) is not null;
    }
}
