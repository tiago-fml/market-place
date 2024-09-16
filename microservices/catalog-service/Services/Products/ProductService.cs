using AutoMapper;
using catalog_service.DTOs.Products;
using catalog_service.Models;
using catalog_service.Repositories;

namespace catalog_service.Services.Products;

public class ProductService(IUnityOfWork unityOfWork, IMapper mapper) : IProductService
{
    public async Task<ProductDto> CreateProductAsync(ProductCreateDto createDto)
    {
        var newProduct = mapper.Map<Product>(createDto);
        await unityOfWork.ProductRepo.AddProductAsync(newProduct);

        await unityOfWork.SaveChangesAsync();
        
        return mapper.Map<ProductDto>(newProduct);
    }

    public Task<ProductDto> UpdateProductAsync(Guid id, ProductUpdateDto updateDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductDto>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}