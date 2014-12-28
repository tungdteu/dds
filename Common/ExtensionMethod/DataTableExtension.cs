using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Common.ExtensionMethod
{
    public static class DataTableExtension
    {
        /// <summary>
        /// Convert to the collection from a table
        /// </summary>
        /// <typeparam name="T">Type of list</typeparam>
        /// <param name="dt">datatable</param>
        /// <returns>please see <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     to get more information</returns>
        public static List<T> ToCollection<T>(this DataTable dt)
        {
            var lst = new List<T>();
            var tClass = typeof(T);
            var pClass = tClass.GetProperties();
            var dc = dt.Columns.Cast<DataColumn>().ToList();
            foreach (DataRow item in dt.Rows)
            {
                var cn = (T)Activator.CreateInstance(tClass);
                foreach (var pc in pClass)
                {   
                    try
                    {
                        var d = dc.Find(c => c.ColumnName == pc.Name);
                        if (d != null)
                            pc.SetValue(cn, item[pc.Name], null);
                    }
                    catch (Exception ex)
                    {
                        Debug.Assert(false, ex.StackTrace);
                    }
                }
                lst.Add(cn);
            }
            return lst;
        }

        /// <summary>
        /// Find to lookup item from a datatable.
        /// </summary>
        /// <param name="dt">Datatable</param>
        /// <param name="columnLookup">Column needed looking up</param>
        /// <returns>please see <see>
        ///         <cref>ILookup</cref>
        ///     </see>
        ///     to understand</returns>
        public static ILookup<object, DataRow> ToLookup(this DataTable dt, string columnLookup)
        {
            return dt.Select().ToLookup(x => x[columnLookup]);
        }
        /// <summary>
        /// set order of columns in datatable
        /// </summary>
        /// <param name="table">datatable</param>
        /// <param name="columnNames">collection of column names</param>
        public static void SetColumnsOrder(this DataTable table, string[] columnNames)
        {
            for (var columnIndex = 0; columnIndex < columnNames.Length; columnIndex++)
                table.Columns[columnNames[columnIndex]].SetOrdinal(columnIndex);
        }
    }
}
