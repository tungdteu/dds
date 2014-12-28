using Common;
using Common.Data.Convert;

namespace DatabaseRespository
{
    public class TblDynamicColumnObjectExtend:tbl_DynamicColumnObject
    {
        public SqlVariantSupportDataType DataType { get; set; }
        public string DataTypeString { get; set; }
    }
}