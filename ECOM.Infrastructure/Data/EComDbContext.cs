using Microsoft.EntityFrameworkCore;
using ECOM.Core.Entities;
using ECOM.Infrastructure.EntityConfiguration;
using System.Reflection;
using ECOM.Core.Entities.OrderAggregate;

namespace ECOM.Infrastructure.Data
{
    public class EComDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public EComDbContext(DbContextOptions<EComDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfiguration(new ProductEntityConfiguration());
            //builder.ApplyConfiguration(new ProductBrandEntityConfiguration());
            //builder.ApplyConfiguration(new ProductTypeEntityConfiguration());
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
