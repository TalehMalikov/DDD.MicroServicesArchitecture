using AppDomain.Dtos.Product;
using MediatR;

namespace Application.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQuery : IRequest<GetProductDto>
    {
        public Guid Id { get; set; }
    }
}
