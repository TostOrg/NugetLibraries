using System.Collections.ObjectModel;

namespace Tost.CollectionsExtensions.Tests;

public class ListExtTests
{
    public static readonly IEnumerable<object[]> ValueData =
        [
            [new List<int>()],
            [new List<int> { 1, 2, 3 }],
            [new List<int> { 1, 2, 3, 0 }],
            [new List<int> { 1, 2, 0, 3, 1, 0 }],
            [new List<(int, int)> { (1, 2), default }],
        ];

    public static readonly IEnumerable<object[]> RefData =
        [
            [new List<List<int>?> { new() { 1 }, null }],
            [new List<Tuple<int, int>?> { new(1, 2), null, new(2, 4) }],
        ];

    [Theory]
    [MemberData(nameof(ValueData))]
    public void FindAllShouldBehaveAsDefaultForValueTypes<T>(List<T> list) where T : IEquatable<T>
    {
        var expected = list.FindAll(match: p => !p.Equals(default));

        var result = list.FindAll(predicate: p => !p.Equals(default));

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(RefData))]
    public void FindAllShouldBehaveAsDefaultForRefTypes<T>(List<T> list)
    {
        var expected = list.FindAll(match: p => p != null);

        var result = list.FindAll(predicate: p => p != null);

        result.Should().BeEquivalentTo(expected);
    }
}
