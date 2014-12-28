using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Common.ExtensionMethod
{
    public static class ListExtension
    {
        /// <summary>
        ///     Convert a list to datatable
        /// </summary>
        /// <typeparam name="T">T type need to convert</typeparam>
        /// <param name="items">items in list object</param>
        /// <returns>it will return a <see>
        ///         <cref>DataTable</cref>
        ///     </see>
        ///     .</returns>
        public static DataTable ConvertToDataTable<T>(this List<T> items)
        {
            var tb = new DataTable(typeof (T).Name);

            var props = typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                var t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];

                for (var i = 0; i < props.Length; i++)
                    values[i] = props[i].GetValue(item, null);

                tb.Rows.Add(values);
            }

            return tb;
        }

        /// <summary>
        ///     Determine of specified type is nullable
        /// </summary>
        /// <param name="t">type of object</param>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof (Nullable<>));
        }

        /// <summary>
        ///     Return underlying type if type is Nullable otherwise return the type.
        /// </summary>
        /// <param name="t">type of object</param>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                return Nullable.GetUnderlyingType(t);
            }

            return t;
        }
    }
}