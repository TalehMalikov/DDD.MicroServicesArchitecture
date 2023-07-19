using AppDomain.Dtos.Product;
using MediatR;

namespace Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductDto>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
