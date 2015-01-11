using System;
using System.Web.UI;

namespace TestControl
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChartJs1.ChartData = "{test}";
            ChartJs1.InvokeChartDrawing();
        }
    }
}