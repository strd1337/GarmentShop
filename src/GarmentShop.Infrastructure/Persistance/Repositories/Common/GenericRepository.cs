using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GarmentShop.Infrastructure.Persistance.Repositories.Common
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : notnull
    {
        protected GarmentShopDbContext dbContext;

        public GenericRepository(GarmentShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TEntity?> GetByIdAsync(
            TId id, 
            CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<TEntity>()
                .FirstOrDefaultAsync(e => e.Id.Equals(id), 
                    cancellationToken);
        }

        public async Task<TEntity?> FirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate, 
            CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<TEntity>()
                .FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task AddAsync(
            TEntity entity, 
            CancellationToken cancellationToken = default)
        {
            await dbContext.Set<TEntity>()
                .AddAsync(entity, cancellationToken);
        }

        public Task UpdateAsync(TEntity entity)
        {
             dbContext.Set<TEntity>().Update(entity);
             return Task.CompletedTask;
        }

        public Task RemoveAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        } 

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<TEntity>()
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetWhereAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<TEntity>().Where(predicate)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> CountAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<TEntity>().CountAsync(cancellationToken);
        }

        public async Task<int> CountWhereAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<TEntity>()
                .CountAsync(predicate, cancellationToken);
        }
    }
}
