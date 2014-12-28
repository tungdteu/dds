using Common.Data.Entity;
using System.Collections.Generic;

namespace Common
{
    public sealed partial class tbl_DataSource:Entity
    {
        public tbl_DataSource()
        {
            WebFormCommonAtribute = new HashSet<tbl_WebForm_Common_Atribute>();
        }
        
        public string DataSourceName { get; set; }
        public short DataSoureType { get; set; }
        public int ObjectHandleValue { get; set; }

        public tbl_DynamicObject DynamicObject { get; set; }
        public ICollection<tbl_WebForm_Common_Atribute> WebFormCommonAtribute { get; set; }
    }
}
