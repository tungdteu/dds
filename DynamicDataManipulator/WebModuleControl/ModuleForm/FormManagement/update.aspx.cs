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
    public partial class Update : Page
    {
        #region Field and PageLoad

        private readonly DatabaseTableRespository _datresp = new DatabaseTableRespository(new UnitOfWork());
        private readonly FormManagerRespository _formresp = new FormManagerRespository(new UnitOfWork());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Response.Redirect("formManagement.aspx");
                Response.End();
            }

            if (!IsPostBack)
            {
                BindData();
                BindRequestForm();
            }
        }

        #endregion

        #region DataBind

        private void BindRequestForm()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                tbl_FormManager entityfromdb = _formresp.Single(int.Parse(Request.QueryString["id"]));
                if (entityfromdb != null)
                {
                    txtFormName.Text = entityfromdb.FormName;
                    for (int index = 0; index < ddlTable.Items.Count; index++)
                    {
                        if (ddlTable.Items[index].Value.ToLower() == entityfromdb.TableManaged.ToLower())
                        {
                            ddlTable.SelectedIndex = index;
                            break;
                        }
                    }
                }
            }
        }

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

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("formmanagement.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
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

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                tbl_FormManager entityfromdb = _formresp.Single(Request.QueryString["id"]);

                if (
                    _formresp.Where(
                        x =>
                            x.TableManaged.ToLower() == ddlTable.Items[ddlTable.SelectedIndex].Value.ToLower() &&
                            x.Id != entityfromdb.Id).FirstOrDefault() != null)
                {
                    lbMessage.Text = "Có một form thao tác với bảng này rồi";
                    return;
                }

                var form = new tbl_FormManager
                {
                    Id = entityfromdb.Id,
                    TableManaged = ddlTable.Items[ddlTable.SelectedIndex].Value,
                    FormName = txtFormName.Text.Trim()
                };

                _formresp.Update(form);
                Response.Redirect("formmanagement.aspx");
            }
        }

        #endregion
    }
}