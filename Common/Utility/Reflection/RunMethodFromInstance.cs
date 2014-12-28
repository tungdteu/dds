using System;

namespace Common.Utility.Reflection
{
    public class RunMethodFromInstance<T>
    {
        public static object InvokeMember(string methodName, T invokeMember, object[] paramPassArg)
        {
            object result = null;

            var type = invokeMember.GetType();
            var methodInfo = type.GetMethod(methodName);

            if (methodInfo != null)
            {
                var parameters = methodInfo.GetParameters();

                if (parameters.Length == 0)
                    result = methodInfo.Invoke(invokeMember, null);
                else
                {
                    if (paramPassArg.Length == 0)
                        throw new ArgumentException("Review total number of args", "paramPassArg");

                    result = methodInfo.Invoke(invokeMember, paramPassArg);
                }
            }

            return result;
        }
    }
}