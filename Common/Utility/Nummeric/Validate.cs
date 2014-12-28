using System;
using System.Diagnostics;

namespace Common.Utility.Nummeric
{
    public class Validate
    {
        public static bool IsNumeric(object expression)
        {
            if (expression == null || expression is DateTime)
                return false;

            if (expression is Int16 || expression is Int32 || expression is Int64 || expression is Decimal ||
                expression is Single || expression is Double || expression is Boolean)
                return true;

            if (expression is string && expression.ToString().Trim() == string.Empty)
                return false;

            try
            {
                if (expression is string)
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    Double.Parse(expression as string);
                else
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    Double.Parse(expression.ToString());
                return true;
            }
            catch(Exception ex)
            {
                Debug.Assert(false,ex.StackTrace);
            } 
            return false;
        }
    }
}