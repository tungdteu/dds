using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;

namespace Common.ExtensionMethod
{
    public static class EpplusExtension
    {
        public static void AddPicture(this ExcelWorksheet ews, string imagePath, int pixelTop = 0, int pixelLeft = 0,
            int pixelWidth = 0, int pixelHeight = 0)
        {
            using (var file = new Bitmap(imagePath))
            {
                ExcelPicture picture = ews.Drawings.AddPicture(file.ToString(), file);
                picture.SetPosition(pixelTop, pixelLeft);
                picture.SetSize(pixelWidth == 0 ? file.Width : pixelWidth, pixelHeight == 0 ? file.Height : pixelHeight);
            }
        }

        public static void SetDefaultValueOfRange(this ExcelRange rng, string value, string fontName = "Arial",
            int fontSize = 12, ExcelHorizontalAlignment alignment = ExcelHorizontalAlignment.CenterContinuous)
        {
            SetDefaultValueOfRange(rng, value, Color.Black, fontName, fontSize, alignment);
        }

        public static void SetDefaultValueOfRange(this ExcelRange rng, string value, Color bestColor,
            string fontName = "Arial", int fontSize = 12,
            ExcelHorizontalAlignment alignment = ExcelHorizontalAlignment.CenterContinuous)
        {
            SetDefaultValueOfRange(rng, value, Color.Black, false, fontName, fontSize, alignment);
        }

        public static void SetDefaultValueOfRange(this ExcelRange rng, string value, Color bestColor, bool bold,
            string fontName = "Arial", int fontSize = 12,
            ExcelHorizontalAlignment alignment = ExcelHorizontalAlignment.CenterContinuous, bool autoWrapText = false)
        {
            rng.Style.Font.Bold = bold;
            rng.Style.Font.Name = fontName;
            rng.Style.HorizontalAlignment = alignment;
            rng.Style.Font.Color.SetColor(bestColor);
            rng.Style.Font.Size = fontSize;
            rng.Merge = true;
            rng.Style.WrapText = autoWrapText;
            rng.Value = value;
        }
    }
}