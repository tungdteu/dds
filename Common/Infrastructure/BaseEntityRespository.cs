using Common.Infrastructure.Contract;
using System;
using System.Linq;
using Common.Data.Entity;

namespace Common.Infrastructure
{
    /// <summary>
    /// Base class for all Sql services base which has T Entity type 
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public abstract class BaseEntityRespository<T> : BaseRepository<T> where T : Entity
    {
        #region Constructor
        public BaseEntityRespository(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
        #endregion

        #region Manipulation object
        /// <summary>
        /// Returns the max id in table
        /// </summary>
        /// <returns>The int variable value</returns>
        public virtual int MaxId()
        {
            return DbSet.Max<Entity>(x => x.Id);
        }

        /// <summary>
        /// Returns the min id in table
        /// </summary>
        /// <returns>The int variable value</returns>
        public virtual int MinId()
        {
            return DbSet.Min<Entity>(x => x.Id);
        }

        /// <summary>
        /// Delete entity by key
        /// </summary>
        /// <param name="id">Indetity key value</param>
        /// <exception cref="Exception">Cannot found entity in the source</exception>
        /// <returns></returns>
        public virtual int DeleteByPrimaryKey(int id)
        {
            var item = SingleOrDefault(id);
            if (item == null)
                throw new Exception("cannot found entity in the source");

            return Delete(item);
        }
        #endregion
    }
}
