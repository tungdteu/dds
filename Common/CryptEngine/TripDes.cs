using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.CryptEngine
{
    /// <summary>
    ///     TripDes manipulator
    /// </summary>
    public static class TripDes
    {
        private static readonly byte[] Bytes = Encoding.ASCII.GetBytes("Ab!#$.31");

        /// <summary>
        ///     Get tripdes value
        /// </summary>
        /// <param name="originalString">Input string</param>
        /// <returns>a string create with security</returns>
        public static string Encrypt(string originalString)
        {
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException
                    ("originalString", "The string which needs to be encrypted can not be null.");
            }
            var cryptoProvider = new DESCryptoServiceProvider();
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(Bytes, Bytes), CryptoStreamMode.Write);
            var writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return System.Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        /// <summary>
        ///     Return tripdes value
        /// </summary>
        /// <param name="cryptedString">Input string</param>
        /// <returns>a string create with non-security</returns>
        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                    ("cryptedString", "The string which needs to be decrypted can not be null.");
            }
            var cryptoProvider = new DESCryptoServiceProvider();
            var memoryStream = new MemoryStream
                (System.Convert.FromBase64String(cryptedString));
            var cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(Bytes, Bytes), CryptoStreamMode.Read);
            var reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
    }
}