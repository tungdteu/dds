using Common.Data.Entity;
using System.Collections.Generic;

namespace Common
{
    public sealed class tbl_Language:Entity
    {
        public tbl_Language()
        {
            this.FormTableColumnControlMappingLabel = new HashSet<tbl_Form_TableColumn_ControlMapping_Label>();
        }

        public string Name { get; set; }

        public ICollection<tbl_Form_TableColumn_ControlMapping_Label> FormTableColumnControlMappingLabel { get; set; }
    }
}
