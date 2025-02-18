using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using online_retail.Repositories.Entities;
using online_retail.Repositories.Interface;

namespace online_retail.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }
        public async Task<Product>CreateProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product>GetProductById(Guid productId)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }
        public async Task<bool> DeleteProductById(Guid productId)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(u => u.ProductId == productId);
            if (product == null) return false;

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
