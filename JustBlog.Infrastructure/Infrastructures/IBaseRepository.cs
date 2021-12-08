using JustBlog.ViewModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustBlog.Infrastructure.Infrastructures
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class where TKey : struct
    {
        /// <summary>
        /// Get all records if isDelete is true,
        /// Get all records have IsDelete is false if isDelete is false
        /// Order by Craeted On
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(bool isDeleted = false);

        /// <summary>
        /// Get Entity by Id
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        TEntity GetById(TKey keyValue);

        /// <summary>
        /// Get Entity by array id
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetById(TKey[] keyValue);

        /// <summary>
        /// Get asynchronous entity by id
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(TKey keyValue);

        /// <summary>
        /// Get all records if isDelete is true,
        /// Get all records have IsDelete is false if isDelete is false
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync(bool isDeleted = false);

        /// <summary>
        /// Add entity into Dbcontext
        /// </summary>
        /// <param name="entity">object</param>
        void Add(TEntity entity);

        /// <summary>
        /// Add asynchronous a entity into Dbcontext
        /// </summary>
        /// <param name="entity">object</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Add a list of entites into DbContext
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Add Asynchronous a list of entites into DbContext
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// If isDelete is true then delete list of entities from database
        /// If isDelete if false then set IsDelete state is true
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <param name="keyValues"></param>
        void Delete(TKey id, bool isDeleted = false);

        /// <summary>
        /// If isDelete is true then delete an entity from database
        /// If isDelete if false then set IsDelete state is true
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <param name="keyValues"></param>
        void Delete(TEntity entity, bool isDeleted = false);

        /// <summary>
        /// If isDelete is true then delete list of entities by codition
        /// If isDelete if false then set IsDelete state is true
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <param name="keyValues"></param>
        void DeleteByCondition(Func<TEntity, bool> condition, bool isDeleted = false);

        /// <summary>
        /// If isDelete is true then delete an entity from database
        /// If isDelete if false then set IsDelete state is true
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <param name="keyValues"></param>
        Task DeleteAsync(TEntity entity, bool isDeleted = false);

        /// <summary>
        /// If isDelete is true then delete list of entities from database
        /// If isDelete if false then set IsDelete state is true
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <param name="keyValues"></param>
        Task DeleteAsync(bool isDeleted = false, params object[] keyValues);

        /// <summary>
        /// If isDelete is true then delete list of entities by codition
        /// If isDelete if false then set IsDelete state is true
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        Task DeleteByConditionAsync(Func<TEntity, bool> condition, bool isDeleted = false);

        /// <summary>
        /// If isDelete is true then delete list of entities by codition
        /// If isDelete if false then set IsDelete state is true
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Func<TEntity, bool> condition, bool isDeleted = false);

        /// <summary>
        /// Count number of record by isDeleted
        /// </summary>
        /// <param name="isDeleted">delete state</param>
        /// <returns>number of records</returns>
        int Count(bool isDeleted = false);

        /// <summary>
        /// Count Asynchronous number of record by isDeleted
        /// </summary>
        /// <param name="isDeleted">delete state</param>
        /// <returns>number of records</returns>
        Task<int> CountAsync(bool isDeleted = false);

        /// <summary>
        /// Get information of page by filter, orderby, pageindex, page size 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="keyword"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagingVm<TEntity> GetPaging(Func<TEntity, bool> filter = null,
            Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null,
            bool isDeleted = false,
            string keyword = null, int pageIndex = 1, int pageSize = 10);
    }
}