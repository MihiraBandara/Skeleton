using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Skeleton.Application.Abstractions.Persistance;
using Skeleton.Domain.Primitives;
using MediatR;

namespace Skeleton.Persistance
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly SkeletonWriteDbContext _dbContext;
        private readonly IMediator _mediator;
        public UnitOfWork(SkeletonWriteDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditableEntities();

            var entitiesWithEvents = _dbContext.ChangeTracker
            .Entries()
            .Select(entry => entry.Entity)
            .OfType<IHasDomainEvents>();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.DomainEvents.ToList();
                entity.ClearDomainEvents();

                foreach (var @event in events)
                {
                    await _mediator.Publish(@event);
                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditableEntities()
        {
            IEnumerable<EntityEntry<BaseDomainAuditableEntity>> entries =
                _dbContext
                    .ChangeTracker
                    .Entries<BaseDomainAuditableEntity>();

            foreach (EntityEntry<BaseDomainAuditableEntity> entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Entity.CreatedAt = DateTime.Now;
                    entityEntry.Entity.UpdatedAt = DateTime.Now;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Entity.UpdatedAt = DateTime.Now;
                }
            }
        }
    }
}
