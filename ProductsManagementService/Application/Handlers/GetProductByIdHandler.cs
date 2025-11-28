using AutoMapper;
using InnoShop.ProductsManagementService.Application.Dtos;
using InnoShop.ProductsManagementService.Application.Queries;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using InnoShop.ProductsManagementService.Domain.Exceptions;

using MediatR;

namespace InnoShop.ProductsManagementService.Application.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductsRepository _productsRepository;

    private readonly IMapper _mapper;

    public GetProductByIdHandler(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(request.Id);

        if (product is null)
        {
            throw new ProductNotFoundException(request.Id);
        }

        return _mapper.Map<ProductDto>(product);
    }
}
