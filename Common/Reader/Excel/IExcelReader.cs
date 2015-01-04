using System.Collections.Generic;
using Common.Object;

namespace Common.Reader.Excel
{
    internal interface IExcelReader
    {
        int ToTalSheetCount { get; set; }

        List<SheetImfomation> Sheets { get; set; }

        int TrimedPosition { get; set; }

        string ErrorLoad { get; set; }

        bool IsErrorOnload { get; }

        void LoadingExcelDataWithSheet(string path);
        void SetDefaultProperty();
    }
}