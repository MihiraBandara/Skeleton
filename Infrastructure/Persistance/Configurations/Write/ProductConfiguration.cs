using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skeleton.Domain.Entities;

namespace Skeleton.Persistance.Configurations.Write
{
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Skeleton");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasConversion(
                productId => productId.Value,
                value => new ProductId(value))
                .HasColumnType("uuid");

            builder.OwnsOne(p => p.Price, pr =>
            {
                pr.Property(p => p.Amount)
                .HasColumnName("Price")
                .HasColumnType("float");
            });

            BaseDomainAuditableEntityConfiguration.Configure<Product>(builder);
        }
    }
}
