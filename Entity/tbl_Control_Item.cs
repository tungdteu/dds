using Common.Data.Entity;
using System.Collections.Generic;

namespace Common
{
    public sealed class tbl_Control_Item:Entity
    {
        public tbl_Control_Item()
        {
            FormTableColumnControlMapping = new HashSet<tbl_Form_TableColumn_ControlMapping>();
        }

        public string ControlName { get; set; }
        public bool HasDataSource { get; set; }
        public bool OnlyForeignKey { get; set; }

        public ICollection<tbl_Form_TableColumn_ControlMapping> FormTableColumnControlMapping { get; set; }
    }
}
