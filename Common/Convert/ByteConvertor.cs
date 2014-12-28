using Common.Data.Verify;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Convert
{
    public class ByteConvertor
    {
        #region Private Field
        private static readonly DateTime Epoch = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
        private static readonly DateTime YearOne = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
        private static readonly long[] TimeToTicMultiplier =
        {
            -1, -1, 100000, 10000, 1000, 100, 10, 1
        };
        private static readonly int[] TimePartOffset =
        {
            -1, -1, 6, 7, 7, 8, 8, 8
        };
        #endregion

        #region Object
        public static object ByteArrayToObject(byte[] arrBytes)
        {
            object obj;

            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                obj = binForm.Deserialize(memStream);
            }

            return obj;    
        }

        public static long GetLong(byte[] src)
        {
            DataLengthVerify.AssertLength(src, 8, "bigint");
            Array.Reverse(src);
            return BitConverter.ToInt64(src, 0);
        }

        public static int GetInt(byte[] src)
        {
            DataLengthVerify.AssertLength(src, 4, "int");
            Array.Reverse(src);
            return BitConverter.ToInt32(src, 0);
        }

        public static short GetShort(byte[] src)
        {
            DataLengthVerify.AssertLength(src, 2, "smallint");
            Array.Reverse(src);
            return BitConverter.ToInt16(src, 0);
        }

        public static bool GetBool(byte[] src)
        {
            DataLengthVerify.AssertLength(src, 1, "bit");
            return src[0] == 1;
        }

        public static string GetUnicodeString(byte[] src)
        {
            if (src.Length % 2 != 0)
            {
                throw new InvalidOperationException("NLS format is invalid.");
            }
            var buf = new char[src.Length / 2];
            for (var pos = 0; pos != src.Length; pos += 2)
            {
                buf[pos / 2] = BitConverter.ToChar(src, pos);
            }
            return new string(buf);
        }

        public static string GetString(byte[] src)
        {
            var res = new char[src.Length];
            for (var i = 0; i != src.Length; i++)
            {
                res[i] = (char)src[i];
            }
            return new string(res);
        }

        public static decimal GetDecimal(byte[] src)
        {
            if (src.Length < 8)
            {
                throw new InvalidOperationException("decimal format is invalid.");
            }
            return new decimal(
                BitConverter.ToInt32(src, 4)
            , src.Length >= 12 ? BitConverter.ToInt32(src, 8) : 0
            , src.Length >= 16 ? BitConverter.ToInt32(src, 12) : 0
            , src[3] != 1
            , src[1]
            );
        }

        public static double GetDouble(byte[] src)
        {
            DataLengthVerify.AssertLength(src, 8, "float");
            Array.Reverse(src);
            return BitConverter.ToDouble(src, 0);
        }

        public static float GetFloat(byte[] src)
        {
            DataLengthVerify.AssertLength(src, 4, "real");
            Array.Reverse(src);
            return BitConverter.ToSingle(src, 0);
        }

        public static DateTime GetDate(byte[] src)
        {
            DataLengthVerify.AssertLength(src, 3, "date");
            long dayNumber = GetInt12(src, 0);
            return YearOne.AddDays(dayNumber);
        }

        public static TimeSpan GetTime(byte[] src)
        {
            var secFraction = 0L;
            for (var i = src.Length - 1; i != 0; i--)
            {
                secFraction <<= 8;
                secFraction += src[i];
            }
            return new TimeSpan(secFraction * TimeToTicMultiplier[src[0]]);
        }

        public static DateTime GetDateTime(byte[] src)
        {
            DataLengthVerify.AssertLength(src, 8, "datetime");
            Array.Reverse(src);
            var res = Epoch.AddDays(BitConverter.ToInt32(src, 4));
            var fraction = BitConverter.ToInt32(src, 0);
            if (fraction == 0)
            {
                return res;
            }
            var millis = (fraction % 300 * 10) / 3;
            var seconds = fraction / 300;
            return res.AddSeconds(seconds).AddMilliseconds(millis);
        }

        public static DateTime GetDateTime2(byte[] src)
        {
            if (src.Length < 7 || src[0] > 7)
            {
                throw new InvalidOperationException("datetime2 format is invalid.");
            }
            var offset = TimePartOffset[src[0]];
            long dayNumber = GetInt12(src, offset - 2);
            var res = YearOne.AddDays(dayNumber);
            var secFraction = 0L;
            for (var i = offset - 3; i != 0; i--)
            {
                secFraction <<= 8;
                secFraction += src[i];
            }
            return res.AddTicks(secFraction * TimeToTicMultiplier[src[0]]);
        }

        public static DateTimeOffset GetDateTimeOffset(byte[] src)
        {
            var dt = GetDateTime2(src);
            var offsetTicks = ((sbyte)src[src.Length - 1] << 8 | src[src.Length - 2]) * 60 * 10000000L;
            var offset = new TimeSpan(offsetTicks);
            return new DateTimeOffset(dt.Add(offset), offset);
        }

        public static int GetInt12(byte[] src, int offset)
        {
            return src[offset + 2] << 16 | src[offset + 1] << 8 | src[offset];
        }
        #endregion
    }
}
