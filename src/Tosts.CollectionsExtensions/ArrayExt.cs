namespace Tost.CollectionsExtensions;

public static class ArrayExt
{
    public static T[] FindAll<T>(this T[] array, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentNullException.ThrowIfNull(predicate);

        var newArray = new T[array.Length];

        var counter = 0;
        for (var i = 0; i < array.Length; i++)
        {
            if (predicate(array[i]) is false)
            {
                continue;
            }

            newArray[i] = array[i];
            counter++;
        }

        Array.Clear(newArray, counter, newArray.Length - counter);

        return newArray;
    }

    public static TOutput[] ConvertAll<TInput, TOutput>(this TInput[] array, Converter<TInput, TOutput> converter)
    {
        return Array.ConvertAll(array, converter);
    }

    public static T? Find<T>(this T[] array, Predicate<T> predicate)
    {
        return Array.Find(array, predicate);
    }
}
