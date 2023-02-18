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
        
        Task<IEnumerable<TEntity>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetWhereAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default);
       
        Task<int> CountAllAsync(
            CancellationToken cancellationToken = default);

        Task<int> CountWhereAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default);
    }
    
}
