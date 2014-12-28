using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using DatabaseRespository;
using DatabaseRespository.Infrastructure;

namespace DynamicDataManipulator.WebModuleControl.ModuleForm.FormManagement
{
    public partial class FormManagement : Page
    {
        #region Field and PageLoad

        private readonly FormManagerRespository _formresp = new FormManagerRespository(new UnitOfWork());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindFormManagement();
        }

        #endregion

        #region DataBind

        private void BindFormManagement()
        {
            List<tbl_FormManager> source = _formresp.ToList();
            grvFormManagement.DataSource = source;
            grvFormManagement.DataBind();
        }

        #endregion

        #region Eventhandler

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var delete = sender as Button;
            if (delete != null)
            {
                int exec = _formresp.DeleteByPrimaryKey(int.Parse(delete.CommandArgument));
                if (exec < 0)
                    lbMessage.Text = "Lỗi không xóa được";
                else
                    lbMessage.Text = "Vừa xóa thành công một bản ghi";

                BindFormManagement();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var update = sender as Button;
            if (update != null)
                Response.Redirect("update.aspx?id=" + update.CommandArgument);
        }

        #endregion
    }
}