using Common.Data.Entity;
using System;
using System.Collections.Generic;

namespace Common
{
    public sealed class tbl_FormManager:Entity
    {
        public tbl_FormManager()
        {
            FormTableColumnControlMapping = new HashSet<tbl_Form_TableColumn_ControlMapping>();
        }
        
        public string FormName { get; set; }
        public string TableManaged { get; set; }

        public ICollection<tbl_Form_TableColumn_ControlMapping> FormTableColumnControlMapping { get; set; }
    }
}
