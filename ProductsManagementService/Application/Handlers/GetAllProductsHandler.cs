using InnoShop.ProductsManagementService.Application.Queries;
using InnoShop.ProductsManagementService.Application.Dtos;
using MediatR;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using AutoMapper;
using System.Reflection.Metadata;


namespace InnoShop.ProductsManagementService.Application.Handlers;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;

    public GetAllProductsHandler(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepository.GetAllAsync(request.QueryObject);
        return _mapper.Map<List<ProductDto>>(products);
    }
}
