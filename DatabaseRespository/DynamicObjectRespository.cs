using Common.Infrastructure;
using Common.Infrastructure.Contract;
using Common;

namespace DatabaseRespository
{
    public class DynamicObjectRespository : BaseEntityRespository<tbl_DynamicObject>
    {
        public DynamicObjectRespository(IUnitOfWork unit)
            : base(unit)
        {
            
        }
    }
}
