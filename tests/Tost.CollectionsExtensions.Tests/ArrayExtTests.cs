namespace Tost.CollectionsExtensions.Tests;

public class ArrayExtTests
{
    public static readonly IEnumerable<object[]> ValueData =
        [
            [Array.Empty<int>()],
            [new int[] { 1, 2, 3 }],
            [new int[] { 1, 2, 3, 0 }],
            [new int[] { 1, 2, 0, 3, 1, 0 }],
            [new (int, int)[] { (1, 2), default }],
        ];

    public static readonly IEnumerable<object[]> RefData =
        [
            [new List<int>?[] { [1], null }],
            [new Tuple<int, int>?[] { new(1, 2), null, new(2, 4) }],
        ];

    [Theory]
    [MemberData(nameof(ValueData))]
    public void FindAllShouldBehaveAsDefaultForValueTypes<T>(T[] arr) where T : IEquatable<T>
    {
        var expected = Array.FindAll(arr, p => !p.Equals(default));

        var result = arr.FindAll(p => !p.Equals(default));

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(RefData))]
    public void FindAllShouldBehaveAsDefaultForRefTypes(object[] arr)
    {
        var expected = Array.FindAll(arr, p => p != null);

        var result = arr.FindAll(p => p != null);

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(ValueData))]
    public void ConvertAllShouldBehaveAsDefaultForValueTypes<T>(T[] arr) where T : IEquatable<T>
    {
        var expected = Array.ConvertAll(arr, p => !p.Equals(default));

        var result = arr.ConvertAll(p => !p.Equals(default));

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(RefData))]
    public void ConvertAllShouldBehaveAsDefaultForRefTypes(object[] arr)
    {
        var expected = Array.ConvertAll(arr, p => p != null);

        var result = arr.ConvertAll(p => p != null);

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(ValueData))]
    public void FindShouldBehaveAsDefaultForValueTypes<T>(T[] arr) where T : IEquatable<T>
    {
        var expected = Array.Find(arr, p => !p.Equals(default));

        var result = arr.Find(p => !p.Equals(default));

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(RefData))]
    public void FindShouldBehaveAsDefaultForRefTypes(object[] arr)
    {
        var expected = Array.Find(arr, p => p != null);

        var result = arr.Find(p => p != null);

        result.Should().BeEquivalentTo(expected);
    }
}
