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
    
    public partial class tbl_FormManager
    {
        public tbl_FormManager()
        {
            this.tbl_Form_TableColumn_ControlMapping = new HashSet<tbl_Form_TableColumn_ControlMapping>();
        }
    
        public int id { get; set; }
        public string FormName { get; set; }
        public string TableManaged { get; set; }
    
        public virtual ICollection<tbl_Form_TableColumn_ControlMapping> tbl_Form_TableColumn_ControlMapping { get; set; }
    }
}
