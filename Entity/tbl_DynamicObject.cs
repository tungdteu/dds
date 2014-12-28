using Common.Data.Entity;
using System.Collections.Generic;


namespace Common
{
    public sealed class tbl_DynamicObject:Entity
    {
        public tbl_DynamicObject()
        {
            DataSource = new HashSet<tbl_DataSource>();
            DynamicObjectDynamicColumnValue = new HashSet<tbl_DynamicObject_DynamicColumn_Value>();
        }

        public string ObjectName { get; set; }

        public ICollection<tbl_DynamicObject_DynamicColumn_Value> DynamicObjectDynamicColumnValue { get; set; }
        public ICollection<tbl_DataSource> DataSource { get; set; }
    }
}
