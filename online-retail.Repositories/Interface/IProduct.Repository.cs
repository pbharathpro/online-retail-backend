using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_retail.Repositories.Entities;

namespace online_retail.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProductById(Guid productId);
        Task<bool> DeleteProductById(Guid userId);

    }
}
