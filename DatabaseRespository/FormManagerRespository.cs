using Common;
using Common.Infrastructure;
using Common.Infrastructure.Contract;

namespace DatabaseRespository
{
    public class FormManagerRespository : BaseEntityRespository<tbl_FormManager>
    {
        public FormManagerRespository(IUnitOfWork unit)
            : base(unit)
        {

        }
    }
}
