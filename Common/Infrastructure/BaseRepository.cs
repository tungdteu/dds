using Common.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Common.Infrastructure
{
    
    /// <summary>
    /// Base class for all SQL based service classes
    /// </summary>
    /// <typeparam name="T">The domain object type</typeparam>
    public abstract class BaseRepository<T> : IDisposable,IBaseRepository<T> where T : class
    {
        #region  Field and property
        private readonly IUnitOfWork _unitOfWork;
        protected internal DbSet<T> DbSet;

        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
        internal DbContext Database { get { return _unitOfWork.Db; } }
        #endregion

        #region Constructor
        /// <summary>
        /// Create a instance 
        /// </summary>
        /// <param name="unitOfWork">Unit of work instance</param>
        protected BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            DbSet = _unitOfWork.Db.Set<T>();
        }
        #endregion

        #region Manipulation object
        /// <summary>
        /// Returns the object with the primary key specifies or throws
        /// </summary>
        /// <typeparam name="T">The type to map the result to</typeparam>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public virtual T Single(object primaryKey)
        {
            var dbResult = DbSet.Find(primaryKey);
            return dbResult;
        }
        /// <summary>
        /// Returns the object with the primary key specifies or the default for the type
        /// </summary>
        /// <typeparam name="T">The type to map the result to</typeparam>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public virtual T SingleOrDefault(object primaryKey)
        {
            var dbResult = DbSet.Find(primaryKey);
            return dbResult;
        }
        /// <summary>
        /// Returns the bool variable that indicate primaryKey belong in T
        /// </summary>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The bool variable </returns>
        public virtual bool Exists(object primaryKey)
        {
            return DbSet.Find(primaryKey) != null;
        }

        public virtual int Insert(T entity)
        {
            dynamic obj = DbSet.Add(entity);
            _unitOfWork.Db.SaveChanges();
            return obj.Id;
        }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Db.SaveChanges();
        }

        public virtual int Delete(T entity)
        {
            if (_unitOfWork.Db.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dynamic obj = DbSet.Remove(entity);
            _unitOfWork.Db.SaveChanges();
            return obj.Id;
        }

        public virtual Dictionary<string, string> GetAuditNames(dynamic dynamicObject)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> AsEnumerable()
        {
            return DbSet.AsEnumerable();
        }

        public virtual List<T> ToList()
        {
            return DbSet.AsEnumerable().ToList();
        }

        public virtual IEnumerable<T> Where(Func<T, int, bool> predicate)
        {
            return AsEnumerable().Where(predicate);
        }

        public virtual IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return AsEnumerable().Where(predicate);
        }
        /// <summary>
        /// Skip element by count number
        /// </summary>
        /// <param name="count">Total number need to skip</param>
        /// <returns>IEnumerable of T</returns>
        public virtual IEnumerable<T> Skip(int count)
        {
            return AsEnumerable().Skip(count);
        }
        /// <summary>
        /// Take element by count number
        /// </summary>
        /// <param name="count">Total number need to take</param>
        /// <returns>IEnumerable of T</returns>
        public virtual IEnumerable<T> Take(int count)
        {
            return AsEnumerable().Take(count);
        }
        /// <summary>
        /// Count all object in db
        /// ** WARNING - Most items should be marked inactive and Updated, not deleted
        /// </summary>
        /// <returns>Total rows effected</returns>
        public virtual int Count()
        {
            return DbSet.Count();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            if (UnitOfWork != null && UnitOfWork.Db!=null)
            {
                UnitOfWork.Db.Dispose();
                GC.SuppressFinalize(this);
            }
        }
        #endregion
    }
}
