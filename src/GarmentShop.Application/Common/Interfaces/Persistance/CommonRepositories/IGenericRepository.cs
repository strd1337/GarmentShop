using GarmentShop.Domain.Common.Models;
using System.Linq.Expressions;

namespace GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories
{
    public interface IGenericRepository<TEntity, TId> 
        where TEntity : Entity<TId>
        where TId : notnull
    {
        Task<TEntity?> GetByIdAsync(
            TId id, 
            CancellationToken cancellationToken = default);

        Task<TEntity?> FirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default);
       
        Task AddAsync(TEntity entity,
            CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity);

        Task RemoveAsync(TEntity entity);

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(string include);
        IQueryable<TEntity> GetAll(string include, string include2);

        IQueryable<TEntity> GetWhere(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default);

        IQueryable<TEntity> GetWhere(
            Expression<Func<TEntity, bool>> predicate,
            string include);

        Task<int> CountAllAsync(
            CancellationToken cancellationToken = default);

        Task<int> CountWhereAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default);
    }
    
}
