using System.Data.Entity;
using catalog_service.Data;
using catalog_service.Models;

namespace catalog_service.Repositories.Products;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var list = await context.Products.ToListAsync();
        return list;
    }

    public async Task<Product?> GetProductByIdAsync(Guid id)
    {
        var product = await context.Products.FirstOrDefaultAsync(x=>x.Id == id);
        return product;
    }

    public async Task AddProductAsync(Product product)
    {
        await context.Products.AddAsync(product);
    }
}