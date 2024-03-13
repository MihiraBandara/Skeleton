using Dapper;
using Skeleton.Application.Abstractions.Persistance;
using System.Data;

namespace Skeleton.Persistance.Repositories
{
    public class GenericReadRepository<TEntity> : IGenericReadRepository<TEntity> where TEntity : class
    {
        private readonly IDbConnection _connection;

        public GenericReadRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<TEntity> GetByIdAsync(Guid id, string tableName, string schemaName = "public")
        {
            var query = $"SELECT * FROM \"{schemaName}\".\"{tableName}\" WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<TEntity>(query, new { Id = id });
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(string tableName, string schemaName = "public")
        {
            var query = $"SELECT * FROM \"{schemaName}\".\"{tableName}\"";
            var entities = await _connection.QueryAsync<TEntity>(query);
            return entities.AsList().AsReadOnly();
        }
    }
}
