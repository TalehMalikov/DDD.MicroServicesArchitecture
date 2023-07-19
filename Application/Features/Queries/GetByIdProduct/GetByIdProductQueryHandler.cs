using AppDomain.Dtos.Product;
using AppDomain.Entities;
using AppDomain.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetProductDto>
    {
        readonly IRepository<Product> _productRepository;
        IMapper _mapper;
        public GetByIdProductQueryHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetAsync(request.Id);
            return _mapper.Map<GetProductDto>(product);
        }
    }
}
