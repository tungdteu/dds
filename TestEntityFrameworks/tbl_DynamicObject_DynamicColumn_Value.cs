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
    
    public partial class tbl_DynamicObject_DynamicColumn_Value
    {
        public int id { get; set; }
        public int ObjectId { get; set; }
        public int ColumnObjectId { get; set; }
        public int RowIndex { get; set; }
        public string Value { get; set; }
    
        public virtual tbl_DynamicColumnObject tbl_DynamicColumnObject { get; set; }
        public virtual tbl_DynamicObject tbl_DynamicObject { get; set; }
    }
}
