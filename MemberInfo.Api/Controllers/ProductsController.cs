using MapsterMapper;
using MediatR;
using MemberInfo.Application.Products.Commands.CreateProduct;
using MemberInfo.Contracts.Products;
using Microsoft.AspNetCore.Mvc;


namespace MemberInfo.Api.Controllers;

[Route("persons/{personId}/products")]
public class ProductsController : ApiController
{

    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    public ProductsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]

    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var command = _mapper.Map<CreateProductCommand>(request);
        var CreateProductResult = await _mediator.Send(command);
        return Ok(CreateProductResult);
    }

}
