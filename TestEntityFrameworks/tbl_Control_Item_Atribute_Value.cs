//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestEntityFrameworks
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Control_Item_Atribute_Value
    {
        public int id { get; set; }
        public int AtributeId { get; set; }
        public int FormTableColumnId { get; set; }
        public string Value { get; set; }
    
        public virtual tbl_Form_TableColumn_ControlMapping tbl_Form_TableColumn_ControlMapping { get; set; }
        public virtual tbl_WebForm_Common_Atribute tbl_WebForm_Common_Atribute { get; set; }
    }
}
