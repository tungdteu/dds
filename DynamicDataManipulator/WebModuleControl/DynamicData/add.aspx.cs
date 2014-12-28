using System;
using System.Linq;
using System.Web.UI;
using Common;
using DatabaseRespository;
using DatabaseRespository.Infrastructure;

namespace DynamicDataManipulator.WebModuleControl.DynamicData
{
    public partial class AddModule : Page
    {
        #region Field and PageLoad

        private readonly DynamicObjectRespository _dymresp = new DynamicObjectRespository(new UnitOfWork());

        #endregion

        #region EventHandler

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("objectmanagement.aspx");
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            lbMessage.Text = string.Empty;

            if (string.IsNullOrEmpty(txtObjectName.Text.Trim()))
            {
                lbMessage.Text = "Nhập tên của đối tượng";
                return;
            }
            
            if (_dymresp.Where(x => x.ObjectName.ToLower() == txtObjectName.Text.Trim()).FirstOrDefault() != null)
            {
                lbMessage.Text = "Không đặt trùng tên object";
                return;
            }

            var dynobject = new tbl_DynamicObject {ObjectName = txtObjectName.Text.Trim()};

            int exec = _dymresp.Insert(dynobject);

            if (exec < 0)
                lbMessage.Text = "Không thêm mới được đối tượng";
            else
                Response.Redirect("objectmanagement.aspx");
        }

        #endregion
    }
}