using BlazorCRUD.Data;
using BlazorCRUD.Implementations;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using SharedLibrary.ProductRepository;

namespace BlazorCRUD.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository prductRepository)
        {
            this._productRepository = prductRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Product>>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<List<Product>>> GetSingelProductAsync(int id)
        {
            var products = await _productRepository.GetProductByIdAsync(id);
            return Ok(products);
        }

        [HttpPost("Save")]
        public async Task<ActionResult<List<Product>>> GetSingelProductAsync(Product model)
        {
            var products = await _productRepository.AddProductAsync(model);
            return Ok(products);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<List<Product>>> UpdateProductAsync(Product model)
        {
            var products = await _productRepository.UpdateProductAsync(model);
            return Ok(products);
        }

        [HttpDelete("Delete{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProductAsync(int id)
        {
            var products = await _productRepository.DeleteProductAsync(id);
            return Ok(products);
        }
    }
}
