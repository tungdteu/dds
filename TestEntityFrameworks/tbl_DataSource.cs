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
    
    public partial class tbl_DataSource
    {
        public tbl_DataSource()
        {
            this.tbl_WebForm_Common_Atribute = new HashSet<tbl_WebForm_Common_Atribute>();
        }
    
        public int id { get; set; }
        public string DataSourceName { get; set; }
        public short DataSoureType { get; set; }
        public int ObjectHandleValue { get; set; }
    
        public virtual tbl_DynamicObject tbl_DynamicObject { get; set; }
        public virtual ICollection<tbl_WebForm_Common_Atribute> tbl_WebForm_Common_Atribute { get; set; }
    }
}
