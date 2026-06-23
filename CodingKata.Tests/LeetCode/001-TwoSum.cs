using Xunit;
using CodingKata.LeetCode;

namespace CodingKata.LeetCode.Tests;

public class TwoSumTests
{
    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    [InlineData(new int[] { -1, 1 }, 0, new int[] { 0, 1 })]
    public void TwoSum_PassArray_ReturnCorrectIndices(int[] nums, int target, int[] expected)
    {
        var result = TwoSum.Solve(nums, target);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TwoSum_TargetNotMet_ReturnEmpty()
    {
        int[] nums = [2, 7, 11, 15];
        int target = 5;

        int[] result = TwoSum.Solve(nums, target);

        Assert.Empty(result);

    }
}