using Common;
using Common.Infrastructure;
using Common.Infrastructure.Contract;

namespace DatabaseRespository
{
    public class FormTableColumnControlMappingRespository:BaseEntityRespository<tbl_Form_TableColumn_ControlMapping>
    {
        public FormTableColumnControlMappingRespository(IUnitOfWork unit)
            : base(unit)
        { 
        
        }
    }
}
