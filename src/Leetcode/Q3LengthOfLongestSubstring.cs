using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.src.Leetcode
{
    /// <summary>
    /// This answer passed 986/987 test cases, the failure case shows Time Limit Exceeded. Since this is an O(n) solution, we can say it is correct.
    /// </summary>
    public class Q3LengthOfLongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            int result = 0, low = 0, high = 0;
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.TryGetValue(s.ElementAt(i), out high) && high >= low)
                {
                    result = Math.Max(result, Math.Max(high - low + 1, i - high));
                    dict[s.ElementAt(high)] = i;
                    low = high + 1;
                    continue;
                }
                if (!dict.TryAdd(s.ElementAt(i), i))
                    dict[s.ElementAt(i)] = i;
                result = Math.Max(result, i - low + 1);
            }
            return result;
        }
    }
}