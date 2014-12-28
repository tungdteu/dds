using System;
using System.Collections.Generic;

namespace Common.Infrastructure.Contract
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Retrieve a single item using it's primary key, exception if not found
        /// </summary>
        /// <param name="primaryKey">The primary key of the record</param>
        /// <returns>T</returns>
        T Single(object primaryKey);
        /// <summary>
        /// Retrieve created by and modified by id's FullName
        /// </summary>
        /// <param name="dynamicObject">The primary key of the record</param>
        /// <returns>T</returns>
        Dictionary<string, string> GetAuditNames(dynamic dynamicObject);
        /// <summary>
        /// Retrieve a single item by it's primary key or return null if not found
        /// </summary>
        /// <param name="primaryKey">Prmary key to find</param>
        /// <returns>T</returns>
        T SingleOrDefault(object primaryKey);
        /// <summary>
        /// Returns all the rows for type T
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> AsEnumerable();
        /// <summary>
        /// Returns all the list of rows for type T
        /// </summary>
        /// <returns></returns>
        List<T> ToList();
        /// <summary>
        /// Returns all the rows for type T which match with predicate FUNC
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Where(Func<T, bool> predicate);
        /// <summary>
        /// Returns all the rows for type T which match with predicate FUNC
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Where(Func<T, int, bool> predicate);
        /// <summary>
        /// Skip number of rows 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Skip(int count);
        /// <summary>
        /// Take number of rows 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Take(int count);
        /// <summary>
        /// Does this item exist by it's primary key
        /// </summary>
        /// <param name="primaryKey">primaryKey</param>
        /// <returns>True or False</returns>
        bool Exists(object primaryKey);
        /// <summary>
        /// Inserts the data into the table
        /// </summary>
        /// <param name="entity">The entity to insert</param>
        /// <returns>Row id</returns>
        int Insert(T entity);
        /// <summary>
        /// Updates this entity in the database using it's primary key
        /// </summary>
        /// <param name="entity">The entity to update</param>
        void Update(T entity);
        /// <summary>
        /// Deletes this entry fro the database
        /// ** WARNING - Most items should be marked inactive and Updated, not deleted
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <returns>Total rows effeccted</returns>
        int Delete(T entity);
        /// <summary>
        /// Count all object in db
        /// ** WARNING - Most items should be marked inactive and Updated, not deleted
        /// </summary>
        /// <returns>Total rows effected</returns>
        int Count();
        /// <summary>
        /// Unit of work(commit, rollback)
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
    }
}
