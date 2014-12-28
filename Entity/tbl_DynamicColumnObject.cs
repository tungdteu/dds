using Common.Data.Entity;
using System.Collections.Generic;

namespace Common
{
    public class tbl_DynamicColumnObject:Entity
    {
        public tbl_DynamicColumnObject()
        {
            DynamicObjectDynamicColumnValue = new HashSet<tbl_DynamicObject_DynamicColumn_Value>();
        }

        public int ObjectId { get; set; }
        public string ObjectColumnName { get; set; }
        public short ObjectDataType { get; set; }

        public ICollection<tbl_DynamicObject_DynamicColumn_Value> DynamicObjectDynamicColumnValue { get; set; }
    }
}
