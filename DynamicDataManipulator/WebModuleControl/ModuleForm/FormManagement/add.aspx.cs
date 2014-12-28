using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Common;
using DatabaseRespository;
using DatabaseRespository.Infrastructure;
using FakeEntities;

namespace DynamicDataManipulator.WebModuleControl.ModuleForm.FormManagement
{
    public partial class Add : Page
    {
        #region Field and PageLoad

        private readonly DatabaseTableRespository _datresp = new DatabaseTableRespository(new UnitOfWork());
        private readonly FormManagerRespository _formresp = new FormManagerRespository(new UnitOfWork());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();
        }

        #endregion

        #region DataBind

        private void BindData()
        {
            List<DatabaseTable> lst = _datresp.ToList();
            ddlTable.DataSource = lst;
            ddlTable.DataTextField = "Name";
            ddlTable.DataValueField = "name";
            ddlTable.DataBind();
        }

        #endregion

        #region Eventhandler

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            lbMessage.Text = string.Empty;

            if (string.IsNullOrEmpty(txtFormName.Text.Trim()))
            {
                lbMessage.Text = "Nhập tên của form";
                return;
            }

            if (ddlTable.SelectedIndex == -1)
            {
                lbMessage.Text = "Không có bảng để thao tác";
                return;
            }

            if (
                _formresp.Where(x => x.TableManaged.ToLower() == ddlTable.Items[ddlTable.SelectedIndex].Value.ToLower())
                    .FirstOrDefault() != null)
            {
                lbMessage.Text = "Có một form thao tác với bảng này rồi";
                return;
            }

            var form = new tbl_FormManager
            {
                TableManaged = ddlTable.Items[ddlTable.SelectedIndex].Value,
                FormName = txtFormName.Text.Trim()
            };

            int exec = _formresp.Insert(form);

            if (exec < 0)
                lbMessage.Text = "Không thêm mới được form";
            else
                Response.Redirect("formmanagement.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("formmanagement.aspx");
        }

        #endregion
    }
}