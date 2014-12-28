using Common.Data.Entity;

namespace Common
{
    public class tbl_Form_TableColumn_ControlMapping_Label:Entity
    {
        public int FormTableColumnControlMappingItem { get; set; }
        public int LanguageItem { get; set; }
        public string Label { get; set; }

        public virtual tbl_Form_TableColumn_ControlMapping TblFormTableColumnControlMapping { get; set; }
        public virtual tbl_Language TblLanguage { get; set; }
    }
}
