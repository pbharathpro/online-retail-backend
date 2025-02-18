using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_retail.Models.ViewModels;
using online_retail.Services.Implementation;
using online_retail.Services.Interface;

namespace online_retail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase

    {
        private readonly IProductService _productservices;
        public ProductController(IProductService productservices)
        {
            _productservices = productservices;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            List<ProductModel> products = await _productservices.GetAll();
            return Ok(products);
        }
        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel productModel)
        { 
            ProductModel createdProduct = await _productservices.CreateProduct(productModel);
            return Ok(createdProduct);
        }
        [HttpGet("getProductById/{{id}}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            ProductModel productModel = await _productservices.GetProductById(productId);
            return Ok(productModel);
        }
        [HttpDelete("deleteProduct/{{id}}")]
        public async Task<IActionResult> DeleteProductById(Guid id)
        {
            bool isDeleted = await _productservices.DeleteProductById(id);

            if (!isDeleted)
                return NotFound(new { message = "product not found" });

            return Ok(new { message = "Product deleted successfully" });
        }
    }
}
