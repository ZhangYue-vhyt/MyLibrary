using System;

namespace MyLibrary.src.Leetcode
{
    /// <summary>
    /// DP
    /// </summary>
    public class Q5LongestPalindrome
    {
        public string LongestPalindrome(string s)
        {
        var len = s.Length;
        var matrix = new bool[len, len];

        // Initialize matrix
        for (int i = 0; i < len; i++)
            for (int j = i; j < len; j++)
                matrix[i, j] = true;

        // Fill matrix
        for (int i = 1; i < len; i++)
            for (int j = 0; j < i; j++)
                matrix[i, j] = s[i] == s[j] && matrix[i - 1, j + 1];

        var count = 0;
        var start = 0;
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] && i - j + 1 > count)
                {
                    count = i - j + 1;
                    start = j;
                }
            }
        }
        return s.Substring(start, count);
        }
    }
}