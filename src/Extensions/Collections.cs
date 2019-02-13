using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Extensions
{
    public static class CollectionsExtensions
    {
        public static void PrintEnumerable<T>(this IEnumerable<T> ary) =>
            System.Console.WriteLine("[{0}]", String.Join(", ", ary));
        public static void PrintDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dict) =>
            PrintEnumerable(dict.Select(element => "{" + element.Key + ": " + element.Value + "}"));
    }
}