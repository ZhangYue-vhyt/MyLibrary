using System.Collections.Generic;

namespace MyLibrary.src.Leetcode
{
    /// <summary>
    /// O(n) answer.
    /// </summary>
    public class Q1TowSum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var component = target - nums[i];
                int j;
                if (dict.TryGetValue(component, out j))
                    return new int[] { j, i };
                dict.TryAdd(nums[i], i);
            }
            return new int[] {-1, -1 };
        }
    }
}