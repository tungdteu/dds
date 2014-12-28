using Common.Data.Entity;

namespace Common
{
    public class tbl_Control_Item_Atribute_Value:Entity
    {   
        public int AtributeId { get; set; }
        public int FormTableColumnId { get; set; }
        public string Value { get; set; }

        public virtual tbl_Form_TableColumn_ControlMapping FormTableColumnControlMapping { get; set; }
        public virtual tbl_WebForm_Common_Atribute WebFormCommonAtribute { get; set; }
    }
}
