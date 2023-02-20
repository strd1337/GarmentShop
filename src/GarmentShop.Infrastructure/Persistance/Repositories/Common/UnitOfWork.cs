using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.Common.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GarmentShop.Infrastructure.Persistance.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GarmentShopDbContext dbContext;
        private bool isDisposed;
        private readonly Dictionary<Type, object> repositories = new(); 

        public UnitOfWork(GarmentShopDbContext dbContext)
        {
            this.dbContext = dbContext ?? 
                throw new ArgumentNullException(nameof(dbContext));
        }

        public IGenericRepository<TEntity, TId> GetRepository<TEntity, TId>(
            bool hasCustomRepository = false)
                where TEntity : Entity<TId>
                where TId : ValueObject
        {
            if (hasCustomRepository)
            {
                var customRepository = dbContext.GetService<IGenericRepository<TEntity, TId>>();
                if (customRepository is not null)
                {
                    return customRepository;
                }
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new GenericRepository<TEntity, TId>(dbContext);
            }

            return (IGenericRepository<TEntity, TId>)repositories[type];
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    repositories?.Clear();
                    dbContext.Dispose();
                }
            }
            isDisposed = true;
        }
    }
}
