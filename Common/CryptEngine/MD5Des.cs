using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.CryptEngine
{
    /// <summary>
    ///     Md5 manipulator
    /// </summary>
    public class MD5Des
    {
        /// <summary>
        ///     Get Md5 value
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>a string create with security</returns>
        public static string GetMd5Value(string input)
        {
            return (GetMd5Hash(MD5.Create(), input));
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            foreach (byte t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        ///     Verify a hash against a string.
        /// </summary>
        /// <param name="md5Hash">Md5 class</param>
        /// <param name="input">input string</param>
        /// <param name="hash">input string hash</param>
        /// <returns>true or false</returns>
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            var comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            return false;
        }
    }
}