using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skeleton.Domain.Entities;

namespace Skeleton.Persistance.Configurations.Write
{
    internal sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems","Skeleton");

            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.Id).HasConversion(
                orderItemId => orderItemId.Value,
                value => new OrderItemId(value))
                .HasColumnType("uuid");

            builder.OwnsOne(oi => oi.Subtotal, s =>
            {
                s.Property(p => p.Amount)
                .HasColumnName("SubtotalAmount")
                .HasColumnType("float");
            });

            builder.OwnsOne(oi => oi.Quantity, s =>
            {
                s.Property(q => q.Amount)
                .HasColumnName("Quantity")
                .HasColumnType("int");
            });

            builder.Ignore(oi => oi.Product);

            builder.HasOne<Product>()
                   .WithMany()
                   .HasForeignKey(oi => oi.ProductId)
                   .IsRequired();

            builder.Property(oi => oi.ProductId).HasConversion(
                productId => productId.Value,
                value => new ProductId(value))
                .HasColumnType("uuid");

            builder.HasOne<Order>()
                   .WithMany()
                   .HasForeignKey(oi => oi.OrderId)
                   .IsRequired();

            builder.Property(oi => oi.OrderId).HasConversion(
                orderId => orderId.Value,
                value => new OrderId(value))
                .HasColumnType("uuid");

            BaseDomainAuditableEntityConfiguration.Configure<OrderItem>(builder);
        }
    }
}
