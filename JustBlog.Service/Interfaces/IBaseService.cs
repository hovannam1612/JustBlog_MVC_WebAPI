using JustBlog.Service.Entites;
using System.Collections.Generic;

namespace JustBlog.Service.Interfaces
{
    public interface IBaseService<T, TKey>
        where T : class
        where TKey : struct
    {
        /// <summary>
        /// Get all records of entity
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get entity search by id
        /// </summary>
        /// <returns></returns>
        T GetById(TKey id);

        /// <summary>
        /// Insert a new record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ServiceResult Add(T entity);

        /// <summary>
        /// update a record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ServiceResult Update(T entity);

        /// <summary>
        /// Delete a record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceResult Delete(TKey id);

        /// <summary>
        /// Delete records by array ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        ServiceResult DeleleRange(TKey[] ids);
    }
}