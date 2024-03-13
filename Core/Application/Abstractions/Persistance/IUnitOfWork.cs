namespace Skeleton.Application.Abstractions.Persistance
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
