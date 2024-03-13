namespace Skeleton.Application.Abstractions.Persistance
{
    public interface IGenericReadRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid id, string tableName, string schemaName = "public");
        Task<IReadOnlyList<TEntity>> GetAllAsync(string tableName, string schemaName = "public");
    }
}
