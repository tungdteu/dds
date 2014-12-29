using System.Collections.Generic;
using System.Data;

namespace Common.Object
{
    public class SheetImfomation
    {
        #region Property

        public string SheetName { get; set; }

        public List<string> AllColumnsName { get; set; }

        public bool IncludeGraphObject { get; set; }

        public DataTable Data { get; set; }

        #endregion

        #region Method
        /// <summary>
        /// Remove blank row (scan through all items in rows)
        /// </summary>
        public virtual void RemoveBlankRows()
        {
            for (int indexRows = Data.Rows.Count - 1; indexRows >= 0; indexRows--)
            {
                bool foundData = false;

                for (int indexColumns = 0; indexColumns < Data.Columns.Count; indexColumns++)
                {
                    if (!string.IsNullOrEmpty(Data.Rows[indexRows][indexColumns].ToString()))
                    {
                        foundData = true;
                        break;
                    }
                }

                if (foundData == false)
                    Data.Rows.RemoveAt(indexRows);
            }
        }
        /// <summary>
        /// Remove blank columns(scan through all items in rows)
        /// </summary>
        /// <param name="trimedPosition">trimed position of column to define when pg stop</param>
        public virtual void RemoveBlankColumns(int trimedPosition)
        {
            for (int indexColumns = Data.Columns.Count - 1; indexColumns >= 0; indexColumns--)
            {
                bool foundData = false;

                for (int indexRows = 0; indexRows < Data.Rows.Count; indexRows++)
                {
                    if (!string.IsNullOrEmpty(Data.Rows[indexRows][indexColumns].ToString()))
                    {
                        foundData = true;
                        break;
                    }
                }

                if (foundData == false && indexColumns >= trimedPosition)
                {
                    AllColumnsName.Remove(Data.Columns[indexColumns].ColumnName);
                    Data.Columns.Remove(Data.Columns[indexColumns]);
                }
            }
        }

        #endregion
    }
}