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
    
    public partial class tbl_DynamicColumnObject
    {
        public tbl_DynamicColumnObject()
        {
            this.tbl_DynamicObject_DynamicColumn_Value = new HashSet<tbl_DynamicObject_DynamicColumn_Value>();
        }
    
        public int id { get; set; }
        public int ObjectId { get; set; }
        public string ObjectColumnName { get; set; }
        public short ObjectDataType { get; set; }
    
        public virtual ICollection<tbl_DynamicObject_DynamicColumn_Value> tbl_DynamicObject_DynamicColumn_Value { get; set; }
    }
}
