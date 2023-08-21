using MemberInfo.Contracts.Products;
using Microsoft.AspNetCore.Mvc;


namespace MemberInfo.Api.Controllers;

[Route("persons/{personId}/products")]
public class ProductsController : ApiController
{
    [HttpPost]

    public IActionResult CreateProduct(
        string personId,
        CreateProductRequest request
    ){
        return Ok(request);
    }
    
}
