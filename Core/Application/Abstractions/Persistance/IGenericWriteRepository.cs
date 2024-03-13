using System.Linq.Expressions;

namespace Skeleton.Application.Abstractions.Persistance
{
    public interface IGenericWriteRepository<TEntity> where TEntity : class
    {

        public Task<TEntity> Add(TEntity entity);

        public Task Update(TEntity entity);

        public Task UpdateRange(List<TEntity> entities);

        public Task Delete(TEntity entity);

        public Task DeleteRange(List<TEntity> range);

        public Task AddRange(List<TEntity> range);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
