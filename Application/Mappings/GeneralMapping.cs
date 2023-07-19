using AppDomain.Dtos.Product;
using AppDomain.Entities;
using Application.Features.Commands.CreateProduct;
using AutoMapper;

namespace Application.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<GetProductDto,Product>()
                .ReverseMap();
            CreateMap<CreateProductCommand, Product>()
                .ForMember(p => p.Id, option => option.Ignore())
                .ReverseMap();


            CreateMap<CreateProductDto, Product>()
                .ForMember(p => p.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}
