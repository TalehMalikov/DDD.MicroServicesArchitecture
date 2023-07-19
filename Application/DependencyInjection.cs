using AppDomain.Dtos.Product;
using Application.Features.Commands.CreateProduct;
using Application.Features.Queries.GetAllProduct;
using Application.Features.Queries.GetByIdProduct;
using Application.Mappings;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRequestHandler<CreateProductCommand, CreateProductDto>), typeof(CreateProductCommandHandler));
            services.AddScoped(typeof(IRequestHandler<GetAllProductQuery, List<GetProductDto>>), typeof(GetAllProductQueryHandler));
            services.AddScoped(typeof(IRequestHandler<GetByIdProductQuery, GetProductDto>), typeof(GetByIdProductQueryHandler));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GeneralMapping());
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>();

            return services;
        }
    }
}
