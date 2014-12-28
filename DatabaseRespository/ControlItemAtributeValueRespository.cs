using Common;
using Common.Infrastructure;
using Common.Infrastructure.Contract;

namespace DatabaseRespository
{
    public class ControlItemAtributeValueRespository:BaseEntityRespository<tbl_Control_Item_Atribute_Value>
    {
        public ControlItemAtributeValueRespository(IUnitOfWork unit)
            :base(unit)
        {

        }
    }
}
