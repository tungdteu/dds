using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Common.ExtensionMethod
{
    public static class StringExtension
    {
        /// <summary>
        /// count words in this string
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>int</returns>
        public static int WordCount(this string str)
        {
            return str.Split(new[] {' ', '.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        /// <summary>
        /// get left string of a string
        /// </summary>
        /// <param name="str">string</param>
        /// <param name="count">how many element will take</param>
        /// <returns>string</returns>
        public static string Left(this string str, int count)
        {
            return str.Substring(0, count);
        }
        /// <summary>
        /// get right string of a string
        /// </summary>
        /// <param name="str">string</param>
        /// <param name="count">how many element will take</param>
        /// <returns>string</returns>
        public static string Right(this string str, int count)
        {
            return str.Substring(str.Length - count, count);
        }

        public static string Mid(this string str, int index, int count)
        {
            return str.Substring(index, count);
        }

        public static string Take(this string str, int count, bool ellipsis = false)
        {
            var lengthToTake = Math.Min(count, str.Length);
            var cutDownString = str.Substring(0, lengthToTake);

            if (ellipsis && lengthToTake < str.Length)
                cutDownString += "...";

            return cutDownString;
        }

        public static string Skip(this string str, int count)
        {
            var startIndex = Math.Min(count, str.Length);
            var cutDownString = str.Substring(startIndex - 1);

            return cutDownString;
        }

        public static string Reverse(this string str)
        {
            var chars = str.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }

        public static string With(this string str, params object[] args)
        {
            return string.Format(str, args);
        }

        public static string StripHtml(this string html)
        {
            if (string.IsNullOrEmpty(html))
                return string.Empty;

            return Regex.Replace(html, @"<[^>]*>", string.Empty);
        }

        public static bool Match(this string str, string pattern)
        {
            return Regex.IsMatch(str, pattern);
        }

        public static string[] SplitIntoChunks(this string str, int chunkSize)
        {
            if (string.IsNullOrEmpty(str))
                return new[] {""};

            var stringLength = str.Length;

            var chunksRequired = (int) Math.Ceiling(stringLength/(decimal) chunkSize);
            var stringArray = new string[chunksRequired];

            var lengthRemaining = stringLength;

            for (var i = 0; i < chunksRequired; i++)
            {
                var lengthToUse = Math.Min(lengthRemaining, chunkSize);
                var startIndex = chunkSize*i;
                stringArray[i] = str.Substring(startIndex, lengthToUse);

                lengthRemaining = lengthRemaining - lengthToUse;
            }

            return stringArray;
        }

        public static string Join(this string str,IEnumerable<object> array)
        {
            if (array == null)
                return "";

            return string.Join(str, array.ToArray());
        }

        public static string Join(this string seperator,object[] array)
        {
            if (array == null)
                return "";

            return string.Join(seperator, array);
        }
    }
}   