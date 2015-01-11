using System;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiniSharePointComponent.Js;

namespace MiniSharePointComponent.Html5Control
{
    /// <summary>
    /// A register jquery control
    /// </summary>
    /// <remarks>
    /// Step by step for user who have no exp in Server control development domain
    /// http://msdn.microsoft.com/en-us/library/vstudio/yhzc935f%28v=vs.100%29.aspx
    /// </remarks>
    [Browsable(false)]    
    public class JQueryRegisterControl : CompositeDataBoundControl
    {
        protected override void OnPagePreLoad(object sender, EventArgs e)
        {
            base.OnPagePreLoad(sender, e);
            JavaScriptHelper.Include_JQuery(Page.ClientScript);   
        }

        protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
        {
            return 0;
        }
    }
}

