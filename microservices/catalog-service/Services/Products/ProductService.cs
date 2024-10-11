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

    public async Task<ProductDto?> UpdateProductAsync(Guid id, ProductUpdateDto updateDto)
    {
        var product = await unityOfWork.ProductRepo.GetProductByIdAsync(id);
        if (product == null)
        {
            return null;
        }
        
        mapper.Map(updateDto, product);

        await unityOfWork.SaveChangesAsync();
        
        return mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto?> GetProductByIdAsync(Guid id)
    {
        var product = await unityOfWork.ProductRepo.GetProductByIdAsync(id);
        return mapper.Map<ProductDto>(product);
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        var list = await unityOfWork.ProductRepo.GetProductsAsync();
        return mapper.Map<List<ProductDto>>(list);
    }

    public async Task<ProductDto?> DeleteProductAsync(Guid id)
    {
        var product = await unityOfWork.ProductRepo.GetProductByIdAsync(id);
        if (product == null)
        {
            return null;
        }
        
        await unityOfWork.ProductRepo.DeleteProductAsync(product);
        
        return mapper.Map<ProductDto>(product);
    }
}