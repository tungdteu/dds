using Common;
using Common.Infrastructure;
using Common.Infrastructure.Contract;

namespace DatabaseRespository
{
    public class ControlItemRespository:BaseEntityRespository<tbl_Control_Item>
    {
        public ControlItemRespository(IUnitOfWork unit)
            : base(unit)
        {
              
        }
    }
}
