using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Common;
using DatabaseRespository;
using DatabaseRespository.Infrastructure;
using FakeEntities;

namespace DynamicDataManipulator.WebModuleControl.ModuleForm.FormMappingManagement
{
    public partial class Add : Page
    {
        private readonly ControlItemRespository _ctrresp = new ControlItemRespository(new UnitOfWork());
        private readonly DatabaseTableRespository _datresp = new DatabaseTableRespository(new UnitOfWork());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                BindColumnData();
                BindControlItem();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
        }

        protected void ddlTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindColumnData();
        }

        #region DataBind

        private void BindControlItem()
        {
            List<tbl_Control_Item> lst = _ctrresp.ToList().Where(x => x.OnlyForeignKey == false).ToList();
            ddlControlMapping.DataSource = lst;
            ddlControlMapping.DataTextField = "ControlName";
            ddlControlMapping.DataValueField = "id";
            ddlControlMapping.DataBind();
        }

        private void BindColumnData()
        {
            if (ddlTable.SelectedIndex >= 0)
            {
                using (
                    var datcolresp = new DatabaseColumnRespository(new UnitOfWork(),
                        ddlTable.Items[ddlTable.SelectedIndex].Value))
                {
                    List<DatabaseColumn> lst =
                        datcolresp.AsEnumerable().Where(x => (!(x.PrimaryKey == true && x.IsIdentity))).ToList();
                    ddlColumnOfTable.DataSource = lst;
                    ddlColumnOfTable.DataTextField = "ColumnName";
                    ddlColumnOfTable.DataValueField = "ColumnName";
                    ddlColumnOfTable.DataBind();
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
    }
}