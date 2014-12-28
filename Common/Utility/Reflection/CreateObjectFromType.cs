using System;
using System.Diagnostics;

namespace Common.Utility.Reflection
{
    public class CreateObjectFromType
    {
        public T GetInstance<T>(string type)
        {
            var typeDuplicate = Type.GetType(type);
            Debug.Assert(typeDuplicate != null, "typeDuplicate != null");
            return (T)Activator.CreateInstance(typeDuplicate);
        }
    }
}
