using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_retail.Models.ViewModels;

namespace online_retail.Services.Interface
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAll();
        Task<ProductModel> CreateProduct(ProductModel productmodel);
        Task<ProductModel> GetProductById(Guid productId);
        Task<bool> DeleteProductById(Guid productId);

    }
}
