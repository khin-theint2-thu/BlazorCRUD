using BlazorCRUD.Data;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using SharedLibrary.ProductRepository;

namespace BlazorCRUD.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Product> AddProductAsync(Product model)
        {
            
            var data = _appDbContext.Products.Add(model).Entity;
            await _appDbContext.SaveChangesAsync();
            return data;
        }

        public async Task<Product>  DeleteProductAsync(int productId)
        {
            
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x=>x.Id == productId);
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _appDbContext.Products.ToListAsync();
        }

        public async Task<Product>  GetProductByIdAsync(int productId)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(_=>_.Id == productId);
            if (product is null)return null;
            return product;
        }

        public async Task<Product>  UpdateProductAsync(Product model)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(_ => _.Id == model.Id);
            if (product is null) return null;
            product.Name = model.Name;
            product.Quantity = model.Quantity;
            await _appDbContext.SaveChangesAsync();
            return await _appDbContext.Products.FirstOrDefaultAsync(_ => _.Id == model.Id)?? product;
        }
    }
}
