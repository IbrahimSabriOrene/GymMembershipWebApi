using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using MemberInfo.Application.Products.Commands.CreateProduct;
using MemberInfo.Contracts.Products;
using MemberInfo.Domain.Products.ValueObjects;

namespace MemberInfo.Api.Common.Mapping;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateProductRequest, CreateProductCommand >();
    }
}
