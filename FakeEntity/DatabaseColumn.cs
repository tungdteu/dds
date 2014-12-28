namespace FakeEntities
{
    public class DatabaseColumn
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public short MaxLength { get; set; }
        public bool IsNullable { get; set; }
        public bool IsIdentity { get; set; }
        public bool? PrimaryKey { get; set; }
    }
}
