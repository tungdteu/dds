using Common.Infrastructure;
using Common.Infrastructure.Contract;
using Common;
using System.Collections.Generic;
using System.Linq;
using Common.Data.Convert;

namespace DatabaseRespository
{
    public class DynamicColumnObjectRespository : BaseEntityRespository<tbl_DynamicColumnObject>
    {
        public DynamicColumnObjectRespository(IUnitOfWork unit)
            : base(unit)
        {
              
        }

        public virtual IEnumerable<TblDynamicColumnObjectExtend> AsEnumerableExtends()
        { 
            var temp=from p in AsEnumerable()
                     select new TblDynamicColumnObjectExtend
                     {
                         DynamicObjectDynamicColumnValue=p.DynamicObjectDynamicColumnValue,
                         Id=p.Id,
                         ObjectColumnName=p.ObjectColumnName,
                         ObjectDataType=p.ObjectDataType,
                         ObjectId=p.ObjectId,
                         DataType=SqlVariantDataConvertor.Convert(p.ObjectDataType),
                         DataTypeString = SqlVariantDataConvertor.Convert(p.ObjectDataType).ToString()
                     };

            return temp;
        }

        public virtual List<TblDynamicColumnObjectExtend> ToListExtends()
        {
            return AsEnumerableExtends().ToList();
        }
    }
}
