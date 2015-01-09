using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniSharePointComponent.Html5Control
{
    [Browsable(false)]
    public class JQueryRegisterControl : WebControl
    {
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write("<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js\"></script>");
        }
    }
}