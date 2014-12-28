using Common.Infrastructure;
using Common.Infrastructure.Contract;
using FakeEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseRespository
{
    public class DatabaseColumnRespository : BaseRepository<DatabaseColumn>
    {
        public string TableName { get; private set; }

        public DatabaseColumnRespository(IUnitOfWork unit,string tableName)
            :base(unit)
        {
            TableName = tableName;
        }

        public override IEnumerable<DatabaseColumn> AsEnumerable()
        {
            return UnitOfWork.Db.Database.SqlQuery<DatabaseColumn>(string.Format(@"SELECT * FROM 
                                                                                    (
	                                                                                    SELECT 
	                                                                                    c.name 'ColumnName',
                                                                                        t.Name 'DataType',
                                                                                        c.max_length 'MaxLength',
                                                                                        c.is_nullable 'IsNullable',
	                                                                                    c.is_identity 'IsIdentity',
                                                                                        i.is_primary_key 'PrimaryKey'
                                                                                    FROM    
                                                                                        sys.columns c
                                                                                    INNER JOIN 
                                                                                        sys.types t ON c.system_type_id = t.system_type_id
                                                                                    LEFT OUTER JOIN 
                                                                                        sys.index_columns ic ON ic.object_id = c.object_id AND ic.column_id = c.column_id
                                                                                    LEFT OUTER JOIN 
                                                                                        sys.indexes i ON ic.object_id = i.object_id AND ic.index_id = i.index_id
                                                                                    WHERE
                                                                                        OBJECT_NAME(c.object_id)='{0}'

                                                                                    )A
                                                                                    WHERE A.[Datatype]<>'sysname'", TableName));
        }

        public override int Count()
        {
            return base.AsEnumerable().Count();
        }

        public override int Delete(DatabaseColumn entity)
        {
            throw new NotSupportedException("Cannot hook to SQL Server System");
        }

        public override bool Exists(object primaryKey)
        {
            return Single(primaryKey) != null;
        }

        public override List<DatabaseColumn> ToList()
        {
            return AsEnumerable().ToList();
        }

        public override int Insert(DatabaseColumn entity)
        {
            throw new NotSupportedException("Cannot hook to SQL Server System");
        }

        public override DatabaseColumn Single(object primaryKey)
        {
            return AsEnumerable().FirstOrDefault(x => String.Equals(x.ColumnName, primaryKey.ToString(), StringComparison.CurrentCultureIgnoreCase));
        }

        public override DatabaseColumn SingleOrDefault(object primaryKey)
        {
            return Single(primaryKey);
        }

        public override IEnumerable<DatabaseColumn> Skip(int count)
        {
            return AsEnumerable().Skip(count);
        }

        public override IEnumerable<DatabaseColumn> Take(int count)
        {
            return AsEnumerable().Take(count);
        }

        public override void Update(DatabaseColumn entity)
        {
            throw new NotSupportedException("Cannot hook to SQL Server System");
        }

        public override IEnumerable<DatabaseColumn> Where(Func<DatabaseColumn, bool> predicate)
        {
            return AsEnumerable().Where(predicate);
        }

        public override IEnumerable<DatabaseColumn> Where(Func<DatabaseColumn, int, bool> predicate)
        {
            return AsEnumerable().Where(predicate);
        }
    }
}
