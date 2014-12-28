using Common.Infrastructure;
using Common.Infrastructure.Contract;
using FakeEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseRespository
{
    public class DatabaseTableRespository : BaseRepository<DatabaseTable>
    {
        public DatabaseTableRespository(IUnitOfWork unit)
            :base(unit)
        { 
        
        }

        public override IEnumerable<DatabaseTable> AsEnumerable()
        {
            return UnitOfWork.Db.Database.SqlQuery<DatabaseTable>("SELECT name,object_id 'ObjectId' FROM sys.tables where name <> 'sysdiagrams'");
        }

        public override int Count()
        {
            return AsEnumerable().Count();
        }

        public override int Delete(DatabaseTable entity)
        {
            throw new NotSupportedException("Cannot hook to SQL Server System");
        }

        public override bool Exists(object primaryKey)
        {
            return Single(primaryKey) != null;
        }

        public override List<DatabaseTable> ToList()
        {
            return AsEnumerable().ToList();
        }

        public override int Insert(DatabaseTable entity)
        {
            throw new NotSupportedException("Cannot hook to SQL Server System");
        }

        public override DatabaseTable Single(object primaryKey)
        {
            return AsEnumerable().FirstOrDefault(x => String.Equals(x.Name, primaryKey.ToString(), StringComparison.CurrentCultureIgnoreCase));
        }

        public override DatabaseTable SingleOrDefault(object primaryKey)
        {
            return Single(primaryKey);
        }

        public override IEnumerable<DatabaseTable> Skip(int count)
        {
            return AsEnumerable().Skip(count);
        }

        public override IEnumerable<DatabaseTable> Take(int count)
        {
            return AsEnumerable().Take(count);
        }

        public override void Update(DatabaseTable entity)
        {
            throw new NotSupportedException("Cannot hook to SQL Server System");
        }

        public override IEnumerable<DatabaseTable> Where(Func<DatabaseTable, bool> predicate)
        {
            return AsEnumerable().Where(predicate);
        }

        public override IEnumerable<DatabaseTable> Where(Func<DatabaseTable, int, bool> predicate)
        {
            return AsEnumerable().Where(predicate);
        }
    }
}
