using System;

namespace Common.Data.Verify
{
    public class DataLengthVerify
    {
        #region Public Method
        /// <summary>
        /// Check length of src to verify src 's type
        /// </summary>
        /// <param name="src">Byte array of object</param>
        /// <param name="length">Length to verify</param>
        /// <param name="name">DataType Name</param>
        public static void AssertLength(byte[] src, int length, string name)
        {
            if (src.Length != length)
                throw new InvalidOperationException(name + " format is invalid");
        }
        #endregion
    }
}
