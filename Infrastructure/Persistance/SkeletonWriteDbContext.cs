using Microsoft.EntityFrameworkCore;
using Skeleton.Domain.Entities;

namespace Skeleton.Persistance
{
    public class SkeletonWriteDbContext : DbContext
    {
        public SkeletonWriteDbContext(DbContextOptions<SkeletonWriteDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(SkeletonWriteDbContext).Assembly,
                WriteConfigurationFilter);
        }

        private static bool WriteConfigurationFilter(Type type) =>
            type.FullName?.Contains("Configurations.Write") ?? false;

    }
}
