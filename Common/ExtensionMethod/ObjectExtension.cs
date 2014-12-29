using System;
using Common.Utility.Object;

namespace Common.ExtensionMethod
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Check is null or empty of a object.
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>true or false</returns>
        public static bool IsNullOrEmpty(this object obj)
        {
            if (obj == null)
                return true;

            return String.IsNullOrEmpty(obj.ToString());
        }
        /// <summary>
        /// Check is datetime type of a object.
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>true or false</returns>
        public static bool IsDateTime(this object obj)
        {
            if (obj.IsNullOrEmpty())
                return false;

            DateTime tempDate;
            return DateTime.TryParse(obj.ToString(), out tempDate);
        }
        /// <summary>
        /// Check is number of object (FUKC .NET why u did not develop the  pefect IsNaN function)
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>true or false</returns>
        public static bool IsNummeric(this object obj)
        {  
            return Utility.Nummeric.Validate.IsNumeric(obj);
        }
        /// <summary>
        /// to extend string to avoid null init .
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public static string ToStringEx(this object str)
        {
            return ReturnValueWithoutException.ReturnString(str);
        }
        /// <summary>
        /// to the int from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>int</returns>
        public static int ToInt(this object value)
        {
            return ReturnValueWithoutException.ReturnInt(value);
        }
        /// <summary>
        /// to the decimal from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(this object value)
        {
            return ReturnValueWithoutException.ReturnDecimal(value);
        }
        /// <summary>
        /// to the float from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>float</returns>
        public static float ToFloat(this object value)
        {
            return ReturnValueWithoutException.ReturnFloat(value);
        }
        /// <summary>
        /// to the long from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>long</returns>
        public static long ToLong(this object value)
        {
            return ReturnValueWithoutException.ReturnLong(value);
        }
        /// <summary>
        /// to the double from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>double</returns>
        public static double ToDouble(this object value)
        {
            return ReturnValueWithoutException.ReturnDouble(value);
        }

        /// <summary>
        /// to the int? from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>it will return a <see>
        ///         <cref>int?</cref>
        ///     </see>
        ///     .</returns>
        public static int? ToIntNullable(this object value)
        {
            return ReturnValueWithoutException.ReturnIntNullable(value);
        }
        /// <summary>
        /// to the decimal? from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>it will return a <see>
        ///         <cref>decimal?</cref>
        ///     </see>
        ///     .</returns>
        public static decimal? ToDecimalNullable(this object value)
        {
            return ReturnValueWithoutException.ReturnDecimalNullable(value);
        }
        /// <summary>
        /// to the double? from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>it will return a <see>
        ///         <cref>double?</cref>
        ///     </see>
        ///     .</returns>
        public static double? ToDoubleNullable(this object value)
        {
            return ReturnValueWithoutException.ReturnDoubleNullable(value);
        }
        /// <summary>
        /// to the float? from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>it will return a <see>
        ///         <cref>float?</cref>
        ///     </see>
        ///     .</returns>
        public static float? ToFloatNullable(this object value)
        {
            return ReturnValueWithoutException.ReturnFloatNullable(value);
        }
        /// <summary>
        /// to the long? from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>it will return a <see>
        ///         <cref>long?</cref>
        ///     </see>
        ///     .</returns>
        public static long? ToLongNullable(this object value)
        {
            return ReturnValueWithoutException.ReturnLongNullable(value);
        }
        /// <summary>
        /// to the bool from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>bool</returns>
        public static bool ToBool(this object value)
        {
            return ReturnValueWithoutException.ReturnBool(value);
        }
        /// <summary>
        /// to the Date from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDate(this object value)
        {
            return ReturnValueWithoutException.ReturnDate(value);
        }
        /// <summary>
        /// to the TimeSpan from a object
        /// </summary>
        /// <param name="value">objectc</param>
        /// <returns>TimeSpan</returns>
        public static TimeSpan ToTimeSpan(this object value)
        {
            return ReturnValueWithoutException.ReturnTimeSpan(value);
        }
        /// <summary>
        /// to the DateTime? from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>it will return a <see>
        ///         <cref>DateTime?</cref>
        ///     </see>
        ///     .</returns>
        public static DateTime? ToDateNullable(this object value)
        {
            return ReturnValueWithoutException.ReturnDateNullable(value);
        }
        /// <summary>
        /// to the TimeSpan? from a object
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>it will return a <see>
        ///         <cref>TimeSpan?</cref>
        ///     </see>
        ///     .</returns>
        public static TimeSpan? ToTimeSpamNullable(this object value)
        {
            return ReturnValueWithoutException.ReturnTimeSpamNullable(value);
        }
    }
}
