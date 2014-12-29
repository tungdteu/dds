using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using Common.ExtensionMethod;
using OfficeOpenXml;

namespace Common.Export
{
    public class ExcelExport
    {
        /// <summary>
        /// Render a excel file from <see cref="DataTable"/> and response it to web browser of client. 
        /// </summary>
        /// <param name="source"><see cref="DataTable"/></param>
        /// <param name="sesponseInstance">Page instance will response in project</param>
        /// <param name="needMapPath">need to rewrite map path</param>
        /// <param name="folderToSave">folder to save excel file (default is null or current folder)</param>
        /// <param name="suggetFileName">Name of suggeted file</param>
        /// <param name="columnGet">Array of getting columns in <see cref="DataTable"/> column collection</param>
        /// <param name="columnNameRedefine">Redefine name of getting columns array</param>
        public static void RenderDownloadFileFromDataTable(DataTable source, Page sesponseInstance,
            bool needMapPath = true, string folderToSave = null, string suggetFileName = "", string[] columnGet = null,
            string[] columnNameRedefine = null)
        {
            if (columnNameRedefine != null && columnGet != null)
            {
                if (columnNameRedefine.Length != columnGet.Length)
                    throw new ArgumentException("columnNameRedefine number must be equal to columnGet",
                        "columnNameRedefine");
            }

            if (columnGet != null && source != null && columnGet.Length > source.Columns.Count)
                throw new ArgumentException("columnGet number must be equal or lower than source column count",
                    "columnGet");

            if (columnGet != null && source != null)
            {
                foreach (var column in columnGet)
                {
                    var found = false;

                    for (var index = 0; index < source.Columns.Count; index++)
                    {
                        if (String.Equals(column, source.Columns[index].ColumnName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found == false)
                        throw new ArgumentException(column + " doesnot belong into source column",
                            "columnGet");
                }

                var undefinecolumn = new List<string>();

                for (var index = 0; index < source.Columns.Count; index++)
                {
                    bool found = false;

                    for (var indexMember = 0; indexMember < columnGet.Length; indexMember++)
                    {
                        if (String.Equals(columnGet[indexMember], source.Columns[index].ColumnName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found == false)
                        undefinecolumn.Add(source.Columns[index].ColumnName.ToLower());
                }

                var reorderstring = columnGet.ToList();
                reorderstring.AddRange(undefinecolumn);

                string[] reorderitem = reorderstring.ToArray();

                source.SetColumnsOrder(reorderitem);
            }

            if (source != null)
            {
                string excuteFile;
                folderToSave = folderToSave == null ? "" : "\\" + folderToSave + "\\";

                if (needMapPath)
                    excuteFile = sesponseInstance.Server.MapPath("~") + folderToSave;
                else
                {
                    if (folderToSave.IsNullOrEmpty())
                        throw new ArgumentException("folderToSave cannot be blank when needMapPath is false",
                            "folderToSave");
                    excuteFile = folderToSave;
                }

                string prefix = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string actualDomain = excuteFile + prefix + suggetFileName + ".xlsx";

                var newFile = new FileInfo(actualDomain);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(actualDomain);
                }

                using (var package = new ExcelPackage(newFile))
                {
                    ExcelWorksheet worksheet =
                        package.Workbook.Worksheets.Add(suggetFileName == string.Empty ? "Sheet1" : suggetFileName);

                    int nextValue=0;

                    for (var index = 0; index < source.Columns.Count; index++)
                    {
                        if (columnGet == null)
                            worksheet.Cells[1, index + 1].Value = source.Columns[index].ColumnName;
                        else
                        {
                            var foundMember = string.Empty;

                            for (int indexColumn = 0; indexColumn < columnGet.Length; indexColumn++)
                            {
                                if (source.Columns[index].ColumnName.ToLower() == columnGet[indexColumn].ToLower())
                                {
                                    foundMember = columnNameRedefine == null
                                        ? columnGet[indexColumn]
                                        : columnNameRedefine[indexColumn];
                                    break;
                                }
                            }

                            if (foundMember != string.Empty)
                            {
                                nextValue = nextValue + 1;
                                worksheet.Cells[1, nextValue].Value = foundMember;
                            }
                        }
                    }

                    for (var index = 0; index < source.Rows.Count; index++)
                    {
                        if (columnGet == null)
                        {
                            for (var indexCol = 0; indexCol < source.Columns.Count; indexCol++)
                                worksheet.Cells[index + 2, indexCol + 1].Value = source.Rows[index][indexCol];
                        }
                        else
                        {
                            int nextColumn = 0;

                            for (int indexCol = 0; indexCol < source.Columns.Count; indexCol++)
                            {
                                bool foundMember = columnGet.Any(t => source.Columns[indexCol].ColumnName.ToLower() == t.ToLower());

                                if (foundMember)
                                {
                                    nextColumn = nextColumn + 1;
                                    worksheet.Cells[index + 2, nextColumn].Value = source.Rows[index][indexCol];
                                }
                            }
                        }
                    }

                    package.Save();
                }

                sesponseInstance.TransmitFileToWebBrowser(actualDomain, false);
            }
            else
                throw new ArgumentException("source cannot be null", "source");
        }

        /// <summary>
        /// Render a excel file from <see>
        ///     <cref>List</cref>
        /// </see>
        ///     and response it to web browser of client. 
        /// </summary>
        /// <param name="source"><see cref="DataTable"/></param>
        /// <param name="sesponseInstance">Page instance will response in project</param>
        /// <param name="needMapPath">need to rewrite map path</param>
        /// <param name="folderToSave">folder to save excel file (default is null or current folder)</param>
        /// <param name="suggetFileName">Name of suggeted file</param>
        /// <param name="columnGet">Array of getting columns in <see cref="DataTable"/> column collection</param>
        /// <param name="columnNameRedefine">Redefine name of getting columns array</param>
        /// <remarks>
        /// Very low performance, please think carefully before use it !
        /// </remarks>
        public static void RenderDownloadFileFromList<T>(List<T> source, Page sesponseInstance,
            bool needMapPath = true, string folderToSave = null, string suggetFileName = "", string[] columnGet = null,
            string[] columnNameRedefine = null)
        {
            DataTable tbl = source.ConvertToDataTable();
            RenderDownloadFileFromDataTable(tbl, sesponseInstance, needMapPath, folderToSave,
                suggetFileName, columnGet, columnNameRedefine);
        }
    }
}