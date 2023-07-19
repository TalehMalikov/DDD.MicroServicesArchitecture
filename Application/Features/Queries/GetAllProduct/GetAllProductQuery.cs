using AppDomain.Dtos.Product;
using MediatR;

namespace Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<List<GetProductDto>>
    {
    }
}
