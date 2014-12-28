using Common.Data.Entity;
using System;
using System.Collections.Generic;

namespace Common
{
    public sealed class tbl_WebForm_Common_Atribute:Entity
    {
        public tbl_WebForm_Common_Atribute()
        {
            ControlItemAtributeValue = new HashSet<tbl_Control_Item_Atribute_Value>();
        }

        public string NameOfAtribute { get; set; }
        public short Type { get; set; }
        public Nullable<int> Datasource { get; set; }

        public ICollection<tbl_Control_Item_Atribute_Value> ControlItemAtributeValue { get; set; }
        public tbl_DataSource DataSource { get; set; }
    }
}
