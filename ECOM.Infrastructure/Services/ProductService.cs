using ECOM.Core.Entities;
using ECOM.Core.Interfaces;
using ECOM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOM.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly EComDbContext _dbContext;

        public ProductService(EComDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}
