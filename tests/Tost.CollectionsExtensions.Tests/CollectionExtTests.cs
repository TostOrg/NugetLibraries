using System.Collections.ObjectModel;

namespace Tost.CollectionsExtensions.Tests;

public class CollectionExtTests
{
    public static readonly IEnumerable<object[]> ValueData =
        [
            [new Collection<int>()],
            [new Collection<int> { 1, 2, 3 }],
            [new Collection<int> { 1, 2, 3, 0 }],
            [new Collection<int> { 1, 2, 0, 3, 1, 0 }],
            [new Collection<(int, int)> { (1, 2), default }],
        ];

    public static readonly IEnumerable<object[]> RefData =
        [
            [new Collection<List<int>?> { new() { 1 }, null }],
            [new Collection<Tuple<int, int>?> { new(1, 2), null, new(2, 4) }],
        ];

    [Theory]
    [MemberData(nameof(ValueData))]
    public void FindAllShouldBehaveAsDefaultForValueTypes<T>(Collection<T> collection) where T : IEquatable<T>
    {
        var expected = new List<T>(collection).FindAll(match: p => !p.Equals(default));

        var result = collection.FindAll(p => !p.Equals(default));

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(RefData))]
    public void FindAllShouldBehaveAsDefaultForRefTypes<T>(Collection<T> collection)
    {
        var expected = new List<T>(collection).FindAll(match: p => p != null);

        var result = collection.FindAll(p => p != null);

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(ValueData))]
    public void ConvertAllShouldBehaveAsDefaultForValueTypes<T>(Collection<T> collection) where T : IEquatable<T>
    {
        var expected = new List<T>(collection).ConvertAll(p => !p.Equals(default));

        var result = collection.ConvertAll(p => !p.Equals(default));

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(RefData))]
    public void ConvertAllShouldBehaveAsDefaultForRefTypes<T>(Collection<T> collection)
    {
        var expected = new List<T>(collection).ConvertAll(p => p != null);

        var result = collection.ConvertAll(p => p != null);

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(ValueData))]
    public void FindShouldBehaveAsDefaultForValueTypes<T>(Collection<T> collection) where T : IEquatable<T>
    {
        var expected = new List<T>(collection).Find(p => p != null);

        var result = collection.Find(p => !p.Equals(default));

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(RefData))]
    public void FindShouldBehaveAsDefaultForRefTypes<T>(Collection<T> collection)
    {
        var expected = new List<T>(collection).Find(p => p != null);

        var result = collection.Find(p => p != null);

        result.Should().BeEquivalentTo(expected);
    }
}
