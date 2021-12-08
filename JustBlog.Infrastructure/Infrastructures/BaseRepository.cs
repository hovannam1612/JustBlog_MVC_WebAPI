using JustBlog.Model.BaseEntity;
using JustBlog.ViewModel.BaseEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustBlog.Infrastructure.Infrastructures
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>
        where TKey : struct
    {
        protected JustBlogDbContext _justBlogDbContext;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(JustBlogDbContext justBlogDbContext)
        {
            _justBlogDbContext = justBlogDbContext;
            _dbSet = _justBlogDbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public int Count(bool isDeleted = false)
        {
            if (!isDeleted)
                return _dbSet.Count(x => x.IsDeleted.Equals(false));
            return _dbSet.Count();
        }

        public async Task<int> CountAsync(bool isDeleted = false)
        {
            if (!isDeleted)
                return await _dbSet.CountAsync(x => x.IsDeleted.Equals(false));
            return await _dbSet.CountAsync();
        }

        public void Delete(TKey id, bool isDeleted = false)
        {
            var entityExist = _dbSet.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (entityExist != null)
            {
                if (!isDeleted)
                {
                    entityExist.IsDeleted = true;
                    _justBlogDbContext.Entry(entityExist).State = EntityState.Modified;
                    return;
                }
                _dbSet.Remove(entityExist);
            }
        }

        public void Delete(TEntity entity, bool isDeleted = false)
        {
            var entityExist = _dbSet.Find(entity);
            if (entityExist != null)
            {
                if (!isDeleted)
                {
                    entityExist.IsDeleted = true;
                    _justBlogDbContext.Entry(entityExist).State = EntityState.Modified;
                    return;
                }
                _dbSet.Remove(entityExist);
            }
        }

        public async Task DeleteAsync(TEntity entity, bool isDeleted = false)
        {
            var entityExist = await _dbSet.FindAsync(entity);
            if (entityExist != null)
            {
                if (!isDeleted)
                {
                    entityExist.IsDeleted = true;
                    _justBlogDbContext.Entry(entityExist).State = EntityState.Modified;
                    return;
                }
                _dbSet.Remove(entityExist);
            }
        }

        public async Task DeleteAsync(bool isDeleted = false, params object[] keyValues)
        {
            var entityExisting = await _dbSet.FindAsync(keyValues);
            if (entityExisting != null)
            {
                if (!isDeleted)
                {
                    entityExisting.IsDeleted = true;
                    _justBlogDbContext.Entry(entityExisting).State = EntityState.Modified;
                    return;
                }
                _dbSet.Remove(entityExisting);
            }
        }

        public void DeleteByCondition(Func<TEntity, bool> condition, bool isDeleted = false)
        {
            var entities = _dbSet.Where(condition);
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    this.Delete(entity, isDeleted);
                }
            }
        }

        public async Task DeleteByConditionAsync(Func<TEntity, bool> condition, bool isDeleted = false)
        {
            var entities = _dbSet.Where(condition);
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    await this.DeleteAsync(entity, isDeleted);
                }
            }
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> condition, bool isDeleted = false)
        {
            var entities = _dbSet.Where(condition);
            if (entities != null)
            {
                if (!isDeleted)
                    return entities.Where(x => x.IsDeleted.Equals(false));
                return entities;
            }
            throw new ArgumentNullException($"not found {typeof(TEntity)}");
        }

        public IEnumerable<TEntity> GetAll(bool isDeleted = false)
        {
            if (!isDeleted)
            {
                return _dbSet.Where(x => x.IsDeleted.Equals(false)).OrderByDescending(x => x.CreatedOn);
            }
            return _dbSet.AsEnumerable().OrderByDescending(x => x.CreatedOn);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool isDeleted = false)
        {
            if (!isDeleted)
            {
                return await _dbSet.Where(x => x.IsDeleted.Equals(false)).ToListAsync();
            }
            return await _dbSet.ToListAsync();
        }

        public TEntity GetById(TKey keyValue)
        {
            return _dbSet.FirstOrDefault(x => x.Id.Equals(keyValue));
        }

        public IEnumerable<TEntity> GetById(TKey[] keyValue)
        {
            return _dbSet.Where(item => keyValue.Contains(item.Id));
        }

        public Task<TEntity> GetByIdAsync(TKey keyValue)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(keyValue));
        }

        public PagingVm<TEntity> GetPaging(Func<TEntity, bool> filter = null, Func<IEnumerable<TEntity>,
            IOrderedEnumerable<TEntity>> orderBy = null,
            bool isDeleted = false,
            string keyword = null, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbSet.AsEnumerable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!isDeleted)
            {
                query = query.Where(x => x.IsDeleted.Equals(false));
            }

            int totalRows = query.Count();
            int totalPage = (int)Math.Ceiling((decimal)totalRows / pageSize);

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new PagingVm<TEntity>(query, pageIndex, pageSize, totalPage);
        }

        public void Update(TEntity entity)
        {
            var entityExisting = _dbSet.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (entityExisting != null)
            {
                _dbSet.Update(entity);
            }
        }
    }
}