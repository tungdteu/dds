using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseRespository;
using DatabaseRespository.Infrastructure;

namespace DynamicDataManipulator.WebModuleControl.DynamicData
{
    public partial class ObjectManagement : Page
    {
        #region Field and PageLoad

        private readonly DynamicObjectRespository _dymobjresp = new DynamicObjectRespository(new UnitOfWork());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindObjectData();
        }

        #endregion

        #region BindData

        private void BindObjectData()
        {
            grvObjectManagement.DataSource = _dymobjresp.ToList();
            grvObjectManagement.DataBind();
        }

        #endregion

        #region EventHandler

        protected void btnColumnDefine_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
                Response.Redirect("columndefine.aspx?id=" + btn.CommandArgument);
        }

        protected void btnDataDefine_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
                Response.Redirect("datadefine.aspx?id=" + btn.CommandArgument);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var btndelete = sender as Button;
            if (btndelete != null)
                Response.Redirect("update.aspx?id=" + btndelete.CommandArgument);
        }

        #endregion
    }
}