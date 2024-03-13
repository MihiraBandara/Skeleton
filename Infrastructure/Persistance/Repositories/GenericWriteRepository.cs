using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Skeleton.Application.Abstractions.Persistance;
using Skeleton.Domain.Entities;
using Skeleton.Domain.Primitives;
using System.Threading;

namespace Skeleton.Persistance.Repositories
{
    public class GenericWriteRepository<TEntity> : IGenericWriteRepository<TEntity> where TEntity : class
    {
        private readonly SkeletonWriteDbContext _dbContext;

        public GenericWriteRepository(SkeletonWriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task AddRange(List<TEntity> range)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(range);
        }

        public async Task Delete(TEntity entity)
        {
           _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task DeleteRange(List<TEntity> range)
        {
            _dbContext.Set<TEntity>().RemoveRange(range);
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateRange(List<TEntity> entities)
        {
           _dbContext.ChangeTracker.Clear();
           _dbContext.UpdateRange(entities);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries =
                _dbContext
                    .ChangeTracker
                    .Entries();

            foreach (var  entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                    entityEntry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
