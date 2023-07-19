using AppDomain.Dtos.Product;
using AppDomain.Entities;
using AppDomain.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDto>
    {
        readonly IRepository<Product> _productRepository;
        IMapper _mapper;
        public CreateProductCommandHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<CreateProductCommand, Product>(request);

            Product p = await _productRepository.InsertAsync(product);

            return _mapper.Map<CreateProductDto>(p);
        }
    }
}
