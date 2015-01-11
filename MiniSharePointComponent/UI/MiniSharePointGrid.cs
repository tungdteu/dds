using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Export;

namespace MiniSharePointComponent.UI
{
    public enum MiniSharePointExportFormat
    {
        Pdf,
        Word,
        Excel
    }

    /// <summary>
    ///     MiniSharePoint Grid going to support below tasks :
    ///     -Export data from datasource to word,excel and pdf format
    ///     -Filtering all columns as automatically header tool (can set visible or invisble)
    ///     -Paging data with very high performance technique,just add name of table and it will automatic paging data
    ///     -Support automatic insert,update,delete from Dyn table
    /// </summary>
    [ToolboxData("<{0}:MiniSharePointGrid runat=server></{0}:MiniSharePointGrid>")]
    public class MiniSharePointGrid : GridView
    {
        public void Export(MiniSharePointExportFormat fileFormat)
        {
            switch (fileFormat)
            {
                case MiniSharePointExportFormat.Excel:
                    ExportAsExcel();
                    break;
                case MiniSharePointExportFormat.Pdf:
                    ExportAsPdf();
                    break;
                case MiniSharePointExportFormat.Word:
                    ExportAsWord();
                    break;
            }
        }

        protected virtual void ExportAsWord()
        {
            throw new NotImplementedException();
        }

        protected virtual void ExportAsPdf()
        {
            throw new NotImplementedException();
        }

        protected virtual void ExportAsExcel()
        {
            if (DataSource == null)
                throw new Exception("Datasource is null");

            // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
            if (DataSource is DataTable)
                ExcelExport.RenderDownloadFileFromDataTable((DataTable) DataSource, Page);
        }

        protected virtual void ExportAsExcel<T>()
        {
            if (DataSource == null)
                throw new Exception("Datasource is null");

            if (DataSource is List<T>)
                ExcelExport.RenderDownloadFileFromList(((List<T>)DataSource),Page);
        }
    }
    
}