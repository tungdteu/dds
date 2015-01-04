using System;

namespace Common.Utility.Object
{
    internal class ReturnValueWithoutException
    {
        public static string ReturnString(object value)
        {
            if (value == null)
                return string.Empty;
            return value.ToString();
        }

        public static int ReturnInt(object value)
        {
            if (value == null)
                return -1;

            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return -1;

            int tempOut;
            int.TryParse(stringToString, out tempOut);
            return tempOut;
        }

        public static decimal ReturnDecimal(object value)
        {
            if (value == null)
                return -1;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return -1;

            decimal tempOut ;

            decimal.TryParse(stringToString, out tempOut);
            return tempOut;
        }

        public static float ReturnFloat(object value)
        {
            if (value == null)
                return -1;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return -1;
            float tempOut;

            float.TryParse(stringToString, out tempOut);
            return tempOut;
        }

        public static long ReturnLong(object value)
        {
            if (value == null)
                return -1;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return -1;
            long tempOut;

            long.TryParse(stringToString, out tempOut);
            return tempOut;
        }

        public static double ReturnDouble(object value)
        {
            if (value == null)
                return -1;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return -1;
            double tempOut;

            double.TryParse(stringToString, out tempOut);
            return tempOut;
        }

        public static bool ReturnBool(object value)
        {
            if (value == null)
                return false;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return false;
            bool tempOut;

            bool.TryParse(stringToString, out tempOut);
            return tempOut;
        }

        public static DateTime ReturnDate(object value)
        {
            if (value == null)
                return DateTime.MinValue;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return DateTime.MinValue;
            DateTime tempOut;

            DateTime.TryParse(stringToString, out tempOut);
            return tempOut;
        }

        public static TimeSpan ReturnTimeSpan(object value)
        {
            if (value == null)
                return TimeSpan.MinValue;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return TimeSpan.MinValue;
            TimeSpan tempOut;

            TimeSpan.TryParse(stringToString, out tempOut);
            return tempOut;
        }

        public static int? ReturnIntNullable(object value)
        {
            if (value == null)
                return null;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return null;
            int tempOut;

            int.TryParse(stringToString, out tempOut);
            return tempOut < 0 ? null : new int?(tempOut);
        }

        public static decimal? ReturnDecimalNullable(object value)
        {
            if (value == null)
                return null;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return null;
            decimal tempOut;

            decimal.TryParse(stringToString, out tempOut);
            return tempOut < 0 ? null : new decimal?(tempOut);
        }

        public static float? ReturnFloatNullable(object value)
        {
            if (value == null)
                return null;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return null;
            float tempOut;

            float.TryParse(stringToString, out tempOut);
            return tempOut < 0 ? null : new float?(tempOut);
        }

        public static long? ReturnLongNullable(object value)
        {
            if (value == null)
                return null;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return null;
            long tempOut;

            long.TryParse(stringToString, out tempOut);
            return tempOut < 0 ? null : new long?(tempOut);
        }

        public static double? ReturnDoubleNullable(object value)
        {
            if (value == null)
                return null;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return null;

            double tempOut;

            double.TryParse(stringToString, out tempOut);
            return tempOut < 0 ? null : new double?(tempOut);
        }

        public static DateTime? ReturnDateNullable(object value)
        {
            if (value == null)
                return null;
            string stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return null;
            DateTime tempOut;

            DateTime.TryParse(stringToString, out tempOut);
            return tempOut == DateTime.MinValue ? null : new DateTime?(tempOut);
        }

        public static TimeSpan? ReturnTimeSpamNullable(object value)
        {
            if (value == null)
                return null;
            var stringToString = value.ToString();

            if (string.IsNullOrEmpty(stringToString))
                return null;
            TimeSpan tempOut;

            TimeSpan.TryParse(stringToString, out tempOut);
            return tempOut == TimeSpan.MinValue ? null : new TimeSpan?(tempOut);
        }
    }
}