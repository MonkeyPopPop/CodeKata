namespace CodingKata.LeetCode;

public class TwoSum
{
    public static int[] Solve(int[] nums, int target) {
        Dictionary<int, int> map = new(nums.Length)
        {
            [nums[0]] = 0
        };

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < 0)
            {
                throw new ArgumentException("Negative numbers are not allowed.");
            }

            int complementNumber = target - nums[i];
            
            if (map.TryGetValue(complementNumber, out int complementIndex))
            {
                return [complementIndex, i];
            }

            map[nums[i]] = i;
        }
    
        return [];
    }
}