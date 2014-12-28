using Common;
using Common.Infrastructure;
using Common.Infrastructure.Contract;

namespace DatabaseRespository
{
    public class DataSourceRespository:BaseEntityRespository<tbl_DataSource>
    {
        public DataSourceRespository(IUnitOfWork unit)
            :base(unit)
        {

        }
    }
}
