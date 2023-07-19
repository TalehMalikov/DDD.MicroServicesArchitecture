using AppDomain.Dtos.Product;
using AppDomain.Entities;
using AppDomain.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<GetProductDto>>
    {
        readonly IRepository<Product> _productRepository;
        IMapper _mapper;
        public GetAllProductQueryHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<GetProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetListAsync();
            return _mapper.Map<List<GetProductDto>>(products);
        }
    }
}
