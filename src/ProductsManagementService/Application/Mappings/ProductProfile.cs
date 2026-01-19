using AutoMapper;
using InnoShop.ProductsManagementService.Application.Dtos;
using InnoShop.ProductsManagementService.Application.Dtos.Requests;
using InnoShop.ProductsManagementService.Domain.Entities;

namespace InnoShop.ProductsManagementService.Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>()
            .ForMember(dest => dest.Name,
                opt => opt.Condition(src => src.Name is not null))
            .ForMember(dest => dest.Description,
                opt => opt.Condition(src => src.Description is not null))
            .ForMember(dest => dest.Price,
                opt => opt.Condition(src => src.Price.HasValue))
            .ForMember(dest => dest.Available,
                opt => opt.Condition(src => src.Available.HasValue));
    }
}
