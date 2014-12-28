using Common.Data.Entity;

namespace Common
{
    public class tbl_DynamicObject_DynamicColumn_Value:Entity
    {
        public int ObjectId { get; set; }
        public int ColumnObjectId { get; set; }
        public int RowIndex { get; set; }

        public virtual tbl_DynamicColumnObject DynamicColumnObject { get; set; }
        public virtual tbl_DynamicObject DynamicObject { get; set; }
    }
}
