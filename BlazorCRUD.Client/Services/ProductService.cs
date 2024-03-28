using SharedLibrary.Models;
using SharedLibrary.ProductRepository;
using System.Net.Http.Json;

namespace BlazorCRUD.Client.Services
{
    public class ProductService : IProductRepository
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {

            this._httpClient = httpClient;

        }
        public async Task<Product> AddProductAsync(Product model)
        {
            var product = await _httpClient.PostAsJsonAsync("api/Product/Save", model);
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            var product = await _httpClient.DeleteAsync($"api/Product/Delete/{productId}");
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var product = await _httpClient.GetAsync("api/Product/GetAll");
            var response = await product.Content.ReadFromJsonAsync<List<Product>>();
            return response!;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await _httpClient.GetAsync($"api/Product/Get{productId}");
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<Product> UpdateProductAsync(Product model)
        {
            var product = await _httpClient.PutAsJsonAsync("api/Product/Update",model);
            var response = await product.Content.ReadFromJsonAsync<Product>();
            return response!;
        }
    }
}
