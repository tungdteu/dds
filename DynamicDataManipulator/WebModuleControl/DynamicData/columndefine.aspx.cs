using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Common.Data.Convert;
using Common.ExtensionMethod;
using DatabaseRespository;
using DatabaseRespository.Infrastructure;

namespace DynamicDataManipulator.WebModuleControl.DynamicData
{
    public partial class ColumnDefine : Page
    {
        private readonly DynamicColumnObjectRespository _dymcolresp =
            new DynamicColumnObjectRespository(new UnitOfWork());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Response.Redirect("objectmanagement.aspx");
                Response.End();
            }
            else if (!IsPostBack)
            {
                BindData();
                BindDataType();
            }
        }

        private void BindDataType()
        {
            IEnumerable<SqlVariantSupportData> variantdatasource =
                from p in Enum.GetValues(typeof (SqlVariantSupportDataType))
                    .Cast<SqlVariantSupportDataType>().ToArray()
                select new SqlVariantSupportData {Id = p.GetHashCode(), Name = p.ToString()};

            /* get Enum from name so good 
            var sqlvar =
                Enum.GetValues(typeof (SqlVariantSupportDataType))
                    .Cast<SqlVariantSupportDataType>()
                    .Where(x => x.ToString().ToLower() == "uniqueIdentifier")
                    .Select(x => x)
                    .FirstOrDefault();
            */

            ddlDataType.DataSource = variantdatasource;
            ddlDataType.DataTextField = "Name";
            ddlDataType.DataValueField = "Id";
            ddlDataType.DataBind();
        }

        private void BindData()
        {
            List<tbl_DynamicColumnObject> allcolumnfromobject =
                _dymcolresp.AsEnumerable()
                    .Where(x => x.ObjectId.ToString(CultureInfo.InvariantCulture) == Request.QueryString["id"].ToLower())
                    .ToList();
            grdview.DataSource = allcolumnfromobject;
            grdview.DataBind();
        }

        protected void grdview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdview.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void grdview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdview.EditIndex = SystemConstant.NonEditGridViewItem;
            BindData();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            lbMessage.Text = string.Empty;

            if (string.IsNullOrEmpty(txtColumnName.Text.Trim()))
            {
                lbMessage.Text = "Không để trống tên cột";
                return;
            }

            if (_dymcolresp.Where(x => x.ObjectColumnName.ToLower() == txtColumnName.Text.Trim()).FirstOrDefault() !=
                null)
            {
                lbMessage.Text = "Không đặt trùng tên cột";
                return;
            }

            var column = new tbl_DynamicColumnObject
            {
                ObjectColumnName = txtColumnName.Text.Trim(),
                ObjectDataType = short.Parse(ddlDataType.Items[ddlDataType.SelectedIndex].Value),
                ObjectId = int.Parse(Request.QueryString["id"])
            };

            int exec = _dymcolresp.Insert(column);

            if (exec < 0)
                lbMessage.Text = "Không thêm mới được đối tượng";
            else
                BindData();
        }
    }
}