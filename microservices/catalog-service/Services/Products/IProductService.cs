using catalog_service.DTOs.Products;

namespace catalog_service.Services.Products;

public interface IProductService
{
    Task<ProductDto> CreateProductAsync(ProductCreateDto createDto);
    Task<ProductDto?> UpdateProductAsync(Guid id, ProductUpdateDto updateDto);
    Task<ProductDto?> GetProductByIdAsync(Guid id);
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> DeleteProductAsync(Guid id);
}