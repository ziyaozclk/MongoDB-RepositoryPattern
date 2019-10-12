using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XMean.Domain.Entities;

namespace XMean.Domain.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : class, IEntity<TPrimaryKey>
    {
        IQueryable<TEntity> GetAll();
        List<TEntity> GetAllList();
        
        Task<List<TEntity>> GetAllListAsync();
        
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        
        TEntity Get(TPrimaryKey id);

        Task<TEntity> GetAsync(TPrimaryKey id);
        
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        
        TEntity FirstOrDefault(TPrimaryKey id);
        
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);
        
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        
        TEntity Insert(TEntity entity);
        
        Task<TEntity> InsertAsync(TEntity entity);
        
        TPrimaryKey InsertAndGetId(TEntity entity);
        
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
        
        TEntity InsertOrUpdate(TEntity entity);
        
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);
        
        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);
        
        Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);
        
        TEntity Update(TEntity entity);
        
        Task<TEntity> UpdateAsync(TEntity entity);

        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);

        Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);
        
        void Delete(TEntity entity);

        Task DeleteAsync(TEntity entity);

        void Delete(TPrimaryKey id);

        Task DeleteAsync(TPrimaryKey id);

        void Delete(Expression<Func<TEntity, bool>> predicate);
        
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
    }
}