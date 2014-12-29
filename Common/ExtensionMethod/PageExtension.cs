using System.IO;
using System.Web.UI;

namespace Common.ExtensionMethod
{
    public static class PageExtension
    {
        public static void TransmitFileToWebBrowser(this Page page, string file, bool needMapPath = true,
            string initialFileName = "", string messageError = "Tập tin không tồn tại hoặc bị di chuyển")
        {
            //DownloadFile
            string url;
            if (needMapPath)
                url = page.Server.MapPath("~") + @"\" + file;
            else
                url = file;

            var fileInfo = new FileInfo(url);

            if (fileInfo.Exists)
            {
                long sz = fileInfo.Length;
                page.Response.ClearContent();
                page.Response.ContentType = "application/octet-stream";

                if (initialFileName.Trim() == string.Empty)
                    page.Response.AddHeader("Content-Disposition",
                        string.Format("attachment; filename = {0}", Path.GetFileName(url)));
                else
                {
                    string extension = Path.GetExtension(url);
                    page.Response.AddHeader("Content-Disposition",
                        string.Format("attachment; filename = {0}", initialFileName + extension));
                }
                page.Response.AddHeader("Content-Length", sz.ToString("F0"));
                page.Response.TransmitFile(url);
                page.Response.End();
            }
            else
                page.ClientScript.RegisterStartupScript(typeof (Page), "MessageToYou",
                    "<script language='javascript'>alert('" + messageError + "');</script>");
        }
    }
}