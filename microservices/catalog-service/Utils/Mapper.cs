using AutoMapper;
using catalog_service.DTOs.Products;
using catalog_service.Models;

namespace catalog_service.Utils;

public class Mapper : Profile
{
    public Mapper()
    {
        #region Products

        CreateMap<Product, ProductDto>();
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<ProductCreateDto, Product>();

        #endregion
        
    }
}