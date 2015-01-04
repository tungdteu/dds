using System;
using System.Collections.Generic;
using System.Data;
using C1.C1Excel;
using Common.Object;

namespace Common.Reader.Excel
{
    public class C1ExcelReader : IExcelReader
    {
        #region ExcelReaderConstructor

        public C1ExcelReader()
        {
            TrimedPosition = 0;
        }

        #endregion

        #region Field

        private C1XLBook _book = new C1XLBook();
        private string _errorLoad = string.Empty;

        #endregion

        #region Property

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

        #endregion

        #region Method

        public void LoadingExcelDataWithSheet(string path)
        {
            //Release Book
            if (_book != null)
            {
                _book.Dispose();
                _book = null;
            }
            //LoadFile
            try
            {
                _book = new C1XLBook();
                _book.Load(path);
                _errorLoad = string.Empty;
            }
            catch (Exception ex)
            {
                _errorLoad = ex.Message;
                SetDefaultProperty();
                return;
            }

            if (_book.Sheets.Count == 0)
            {
                SetDefaultProperty();
                return;
            }

            foreach (XLSheet sheetitem in _book.Sheets)
            {
                int sheetColumnsCount = sheetitem.Columns.Count;
                int sheetRowCount = sheetitem.Rows.Count;

                if (
                    sheetColumnsCount > 0 //SheetColumns not is zero
                    &&
                    sheetRowCount > 0 //SheetRows not is zero
                    )
                {
                    if (Sheets == null)
                        Sheets = new List<SheetImfomation>();

                    var sheetItemInfomation = new SheetImfomation();

                    if (sheetItemInfomation.AllColumnsName == null)
                        sheetItemInfomation.AllColumnsName = new List<string>();

                    if (sheetItemInfomation.Data == null)
                        sheetItemInfomation.Data = new DataTable();

                    sheetItemInfomation.IncludeGraphObject = sheetitem.Shapes.Count > 0;
                    sheetItemInfomation.SheetName = sheetitem.Name;


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

                    for (int indexRows = 0; indexRows < sheetRowCount; indexRows++)
                    {
                        DataRow row = sheetItemInfomation.Data.NewRow();

                        for (int indexCols = 0; indexCols < sheetColumnsCount; indexCols++)
                        {
                            if (sheetitem[indexRows, indexCols].Value != null)
                                row["Cols_" + indexCols] = sheetitem[indexRows, indexCols].Value;
                            else
                                row["Cols_" + indexCols] = "";
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