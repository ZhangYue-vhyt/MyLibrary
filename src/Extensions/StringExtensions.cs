using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Extensions
{
    public static class StringExtensions
    {
        public static string ToFirstUpper(this string str)
        {
            if (str.Length == 0) return str;
            var s = str.Split('.');
            return String.Join(". ", s.Select(
                ele => ele = ele.Trim().FirstOrDefault().ToString().ToUpper() + ele.Substring(1).ToLower()
            ));
        }

        /// <summary>
        /// Count the occurrences of each char in the input string.
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>A dictionary with (key, value) = (char, occurrences)</returns>
        public static IDictionary<char, int> Occurrences(this string str)
        {
            var result = new ConcurrentDictionary<char, int>();
            str.ToList().ForEach(ch => result.AddOrUpdate(ch, 0, (k, v) => v + 1));
            return result;
        }
    }
}