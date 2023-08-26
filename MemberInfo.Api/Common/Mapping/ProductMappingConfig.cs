using Mapster;
using MemberInfo.Application.Products.Commands.CreateProduct;
using MemberInfo.Contracts.Products;
using MemberInfo.Domain.Products;
namespace MemberInfo.Api.Common.Mapping;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateProductRequest request, Guid personId), CreateProductCommand >()
        .Map(dest => dest.PersonId, src => src.personId)
        .Map(dest => dest.ProductName, src => src.request.ProductName)
        .Map(dest => dest.Price, src => src.request.Price)
        .Map(dest => dest.Months, src => src.request.Months);
        config.NewConfig<Product, ProductResponse>()
        .Map(dest => dest.ProductId, src => src.Id.Value) // Map Product's Id to ProductResponse's ProductId
        .Map(dest => dest.ProductName, src => src.ProductName) // Map Product's ProductName to ProductResponse's ProductName
        .Map(dest => dest.Price, src => src.Prices) // Map Product's Prices to ProductResponse's Price
        .Map(dest => dest.Months, src => src.Months) // Map Product's Months to ProductResponse's Months
        .Map(dest => dest.CreationDate, src => src.CreationDate) // Map Product's CreationDate to ProductResponse's CreationDate
        .Map(dest => dest.LastUpdateDate, src => src.LastUpdateDate) // Map Product's LastUpdateDate to ProductResponse's LastUpdateDate
        .Map(dest => dest.PersonId, src => src.PersonId.Value); // Map Product's PersonIds to ProductResponse's PersonIds

    }
}
