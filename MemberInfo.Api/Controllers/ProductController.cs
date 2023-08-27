using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using MemberInfo.Application.Product.Commands;
using MemberInfo.Application.Products.Commands;
using MemberInfo.Contracts.Product;
using Microsoft.AspNetCore.Mvc;

namespace MemberInfo.Api.Controllers;

[Route("api/v1/product")]
public class ProductController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public ProductController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
       var command = _mapper.Map<CreateProductCommand>(request);
       var createProductResult = await _mediator.Send(command);
        return createProductResult.Match(
            product => Ok(_mapper.Map<ProductResponse>(product)),
            problem => Problem(problem)
        );
    }    
}
