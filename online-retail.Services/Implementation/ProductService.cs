using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using online_retail.Models.ViewModels;
using online_retail.Repositories.Entities;
using online_retail.Repositories.Interface;
using online_retail.Services.Interface;

namespace online_retail.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            List<Product> products  = await _productRepo.GetAll();
            List<ProductModel> results = _mapper.Map<List<ProductModel>>(products);
            return results;
        }
        public async Task<ProductModel>GetProductById(Guid productId)
        {
            Product product = await _productRepo.GetProductById(productId);
            ProductModel productModel=_mapper.Map<ProductModel>(product);
            return productModel;
        }
        public async Task<ProductModel> CreateProduct(ProductModel productModel)
        {
            Product newProduct = _mapper.Map<Product>(productModel);
            newProduct.ProductId = Guid.NewGuid();
            Product product = await _productRepo.CreateProduct(newProduct);
            return _mapper.Map<ProductModel>(product);
        }
        public async Task<bool> DeleteProductById(Guid productId)
        {
            return await _productRepo.DeleteProductById(productId);
        }
    }
}
