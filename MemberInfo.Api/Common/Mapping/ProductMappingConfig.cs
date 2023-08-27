using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using MemberInfo.Application.Products.Commands;
using MemberInfo.Contracts.Product;
using MemberInfo.Domain.ProductAggregate;

namespace MemberInfo.Api.Common.Mapping;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateProductRequest, CreateProductCommand>()
        .Map(dest=> dest.Price, src => src.Price)
        .Map(dest => dest.Months, src => src.Months)
        .Map(dest => dest.ProductName, src => src.ProductName);

        config.NewConfig<Product, ProductResponse>()
        .Map(dest => dest.ProductId, src => src.Id.Value) //fix this.
        .Map(dest => dest.ProductName, src => src.ProductName)
        .Map(dest => dest.Price, src => src.Price)
        .Map(dest => dest.Months, src => src.Months);

        
    }
}
