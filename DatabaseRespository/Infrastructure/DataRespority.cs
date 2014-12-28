using Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRespository.Infrastructure
{
    public class DataRespority : DbContext
    {
        public DataRespority()
            : base("db")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
               
        }

        public DbSet<tbl_Control_Item> ControlItem { get; set; }
        public DbSet<tbl_Control_Item_Atribute_Value> ControlItemAtributeValue { get; set; }
        public DbSet<tbl_DataSource> DataSource { get; set; }
        public DbSet<tbl_DynamicColumnObject> DynamicColumnObject { get; set; }
        public DbSet<tbl_DynamicObject> DynamicObject { get; set; }
        public DbSet<tbl_DynamicObject_DynamicColumn_Value> DynamicObjectDynamicColumnValue { get; set; }
        public DbSet<tbl_Form_TableColumn_ControlMapping> FormTableColumnControlMapping { get; set; }
        public DbSet<tbl_FormManager> FormManager { get; set; }
        public DbSet<tbl_WebForm_Common_Atribute> WebFormCommonAtribute { get; set; }
        public DbSet<tbl_Form_TableColumn_ControlMapping_Label> FormTableColumnControlMappingLabel { get; set; }
        public DbSet<tbl_Language> Language { get; set; }

    }
}
