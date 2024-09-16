using catalog_service.DTOs.Products;

namespace catalog_service.Services.Products;

public interface IProductService
{
    Task<ProductDto> CreateProductAsync(ProductCreateDto createDto);
    Task<ProductDto> UpdateProductAsync(Guid id, ProductUpdateDto updateDto);
    Task<List<ProductDto>> GetAllProductsAsync();
    Task DeleteProductAsync(Guid id);
}