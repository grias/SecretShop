using AutoMapper;
using InnoShop.ProductsManagementService.Application.Commands;
using InnoShop.ProductsManagementService.Application.Dtos;
using InnoShop.ProductsManagementService.Application.Dtos.Requests;
using InnoShop.ProductsManagementService.Domain.Entities;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using MediatR;


namespace InnoShop.ProductsManagementService.Application.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{

    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;

    public CreateProductHandler(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productToCreate = _mapper.Map<Product>(request.ProductDto);
        var product = await _productsRepository.CreateAsync(productToCreate);
        return _mapper.Map<ProductDto>(product);
    }
}
