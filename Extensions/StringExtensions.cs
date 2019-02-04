using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyLibrary.StringExtensions
{
    public static class Extension
    {
        public static string ToFirstUpper(this string str)
        {
            if (str.Length == 0) return str;
            var s = str.Split('.');
            return String.Join(". ", s.Select(
                ele => ele = ele.Trim().FirstOrDefault().ToString().ToUpper() + ele.Substring(1).ToLower()
            ));
        }
    }
}