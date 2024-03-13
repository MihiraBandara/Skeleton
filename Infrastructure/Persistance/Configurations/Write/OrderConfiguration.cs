using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skeleton.Domain.Entities;

namespace Skeleton.Persistance.Configurations.Write
{
    internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Skeleton");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).HasConversion(
                orderId => orderId.Value,
                value => new OrderId(value))
                .HasColumnType("uuid");

            builder.Ignore(o => o.OrderItems);

            builder.OwnsOne(o => o.TotalAmount, ta =>
            {
                ta.Property(p => p.Amount)
                .HasColumnName("TotalAmount")
                .HasColumnType("float");
            });

            BaseDomainAuditableEntityConfiguration.Configure<Order>(builder);

        }
    }
}
