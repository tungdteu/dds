using System;
using System.Web.UI;

namespace DynamicDataManipulator.WebModuleControl.DynamicData
{
    public partial class Update : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("objectmanagement.aspx");
        }
    }
}