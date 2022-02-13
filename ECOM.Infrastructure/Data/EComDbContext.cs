using Microsoft.EntityFrameworkCore;
using ECOM.Core.Entities;

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
    }
}
