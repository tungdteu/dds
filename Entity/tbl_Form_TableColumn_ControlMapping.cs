using Common.Data.Entity;
using System;
using System.Collections.Generic;

namespace Common
{
    public sealed class tbl_Form_TableColumn_ControlMapping:Entity
    {
        public tbl_Form_TableColumn_ControlMapping()
        {
            ControlItemAtributeValue = new HashSet<tbl_Control_Item_Atribute_Value>();
        }

        public int FormItem { get; set; }
        public string TableColumnName { get; set; }
        public Nullable<int> ControlItem { get; set; }

        public tbl_Control_Item Control_Item { get; set; }
        public ICollection<tbl_Control_Item_Atribute_Value> ControlItemAtributeValue { get; set; }
        public tbl_FormManager FormManager { get; set; }
    }
}
