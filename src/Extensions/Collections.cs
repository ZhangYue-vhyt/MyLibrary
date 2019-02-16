using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Extensions
{
    public static class CollectionsExtensions
    {
        delegate void PrintDelegate(string str);
        public static void PrintEnumerable<T>(this IEnumerable<T> ary) =>
            System.Console.WriteLine("[{0}]", String.Join(", ", ary));
        public static void PrintDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dict) =>
            PrintEnumerable(dict.Select(element => "{" + element.Key + ": " + element.Value + "}"));

        public static void PrintMatrix<T>(this T[, ] matrix)
        where T : IComparable<T>, IFormattable
        {
            var row = matrix.GetLength(0);
            var col = matrix.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (j < col - 1)
                        System.Console.Write($"{matrix[i,j]}\t");
                    else
                        System.Console.WriteLine(matrix[i, j]);
                }
            }
        }
    }
}