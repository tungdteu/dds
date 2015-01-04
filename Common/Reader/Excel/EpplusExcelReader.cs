using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Common.Object;
using OfficeOpenXml;

namespace Common.Reader.Excel
{
    public class EpplusExcelReader : IExcelReader
    {
        #region Field

        private ExcelPackage _bPackage;
        private string _errorLoad = string.Empty;

        #endregion

        #region IExcelReader Members

        public int ToTalSheetCount { get; set; }

        public List<SheetImfomation> Sheets { get; set; }

        public int TrimedPosition { get; set; }

        public string ErrorLoad
        {
            get { return _errorLoad; }
            set { _errorLoad = value; }
        }

        public bool IsErrorOnload
        {
            get { return _errorLoad.Trim() != string.Empty; }
        }

        public void LoadingExcelDataWithSheet(string path)
        {
            //Release Book
            if (_bPackage != null)
            {
                _bPackage.Dispose();
                _bPackage = null;
            }
            //LoadFile
            try
            {
                _bPackage = new ExcelPackage();
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    _bPackage.Load(stream);
                }
                _errorLoad = string.Empty;
            }
            catch (Exception ex)
            {
                _errorLoad = ex.Message;
                SetDefaultProperty();
                return;
            }

            if (_bPackage.Workbook.Worksheets.Count == 0)
            {
                SetDefaultProperty();
                return;
            }

            foreach (ExcelWorksheet item in _bPackage.Workbook.Worksheets)
            {
                int sheetColumnsCount = item.Dimension == null
                    ? 0
                    : item.Dimension.End == null ? 0 : item.Dimension.End.Column;
                int sheetRowCount = item.Dimension == null ? 0 : item.Dimension.End == null ? 0 : item.Dimension.End.Row;

                if (
                    sheetColumnsCount > 0
                    &&
                    sheetRowCount > 0
                    )
                {
                    if (Sheets == null)
                        Sheets = new List<SheetImfomation>();

                    var sheetItemInfomation = new SheetImfomation();

                    if (sheetItemInfomation.AllColumnsName == null)
                        sheetItemInfomation.AllColumnsName = new List<string>();

                    if (sheetItemInfomation.Data == null)
                        sheetItemInfomation.Data = new DataTable();

                    sheetItemInfomation.SheetName = item.Name;

                    //Create Columns Name
                    for (int indexColumns = 0; indexColumns < sheetColumnsCount; indexColumns++)
                    {
                        var column = new DataColumn
                        {
                            DataType = Type.GetType("System.String"),
                            ColumnName = "Cols_" + indexColumns
                        };
                        sheetItemInfomation.AllColumnsName.Add(column.ColumnName);
                        sheetItemInfomation.Data.Columns.Add(column);
                    }

                    for (int indexRows = 1; indexRows <= sheetRowCount; indexRows++)
                    {
                        DataRow row = sheetItemInfomation.Data.NewRow();

                        for (int indexCols = 1; indexCols <= sheetColumnsCount; indexCols++)
                        {
                            if (item.Cells[indexRows, indexCols].Value != null)
                                row["Cols_" + (indexCols - 1)] = item.Cells[indexRows, indexCols].Value;
                            else
                                row["Cols_" + (indexCols - 1)] = "";
                        }

                        sheetItemInfomation.Data.Rows.Add(row);
                    }

                    sheetItemInfomation.RemoveBlankColumns(TrimedPosition);
                    sheetItemInfomation.RemoveBlankRows();

                    Sheets.Add(sheetItemInfomation);
                    ToTalSheetCount++;
                }
            }
        }

        public void SetDefaultProperty()
        {
            ToTalSheetCount = 0;
            Sheets = null;
        }

        #endregion
    }
}