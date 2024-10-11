using catalog_service.Models;

namespace catalog_service.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product?> GetProductByIdAsync(Guid id);
    Task AddProductAsync(Product product);
    Task DeleteProductAsync(Product product);
}