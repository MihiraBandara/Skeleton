using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skeleton.Domain.Primitives;

namespace Skeleton.Persistance.Configurations.Write
{
    public static class BaseDomainAuditableEntityConfiguration
    {
        public static void Configure<TEntity>(EntityTypeBuilder<TEntity> builder) where TEntity : BaseDomainAuditableEntity
        {
            builder.Property(e => e.CreatedBy)
                .HasColumnType("varchar(200)")
                .IsRequired(false); ;

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasColumnType("timestamp(6)"); ;

            builder.Property(e => e.UpdatedBy)
                .HasColumnType("varchar(200)")
                .IsRequired(false); ;

            builder.Property(e => e.UpdatedAt)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasColumnType("timestamp(6)"); ;
        }
    }
}
