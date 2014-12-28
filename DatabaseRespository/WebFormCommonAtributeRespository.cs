using Common;
using Common.Infrastructure;
using Common.Infrastructure.Contract;

namespace DatabaseRespository
{
    public class WebFormCommonAtributeRespository:BaseEntityRespository<tbl_WebForm_Common_Atribute>
    {
        public WebFormCommonAtributeRespository(IUnitOfWork unit)
            :base(unit)
        { 
            
        }
    }
}
