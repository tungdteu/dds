using Common.Infrastructure;
using Common.Infrastructure.Contract;
using Common;

namespace DatabaseRespository
{
    public class DynamicObjectDynamicColumnValueRespository : BaseEntityRespository<tbl_DynamicObject_DynamicColumn_Value>
    {
        public DynamicObjectDynamicColumnValueRespository(IUnitOfWork unit)
            : base(unit)
        {
          
        }
    }
}
