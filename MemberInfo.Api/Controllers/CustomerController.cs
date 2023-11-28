using Microsoft.AspNetCore.Mvc;
using MediatR;
using MapsterMapper;
using Customer.Contracts.Customers;
using MemberInfo.Application.Customers.Commands;
namespace Customer.Api.Controllers;


[Route("/customer")]

public class CustomerController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    public CustomerController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost("createUser")]
    public async Task<IActionResult> CreateUser(CustomerRegisterRequest request)
    {
        var command = _mapper.Map<CreateCustomerCommand>(request);
        var CreateCustomerResult = await _mediator.Send(command);
        return CreateCustomerResult.Match(
            customer => Ok(_mapper.Map<CustomerRegisterResponse>(customer)),
            error => Problem(error)
            );
    }



    //public async Task<IActionResult> GetUserById()
    //{
    //    await Task.CompletedTask;
    //    return Ok(Array.Empty<string>());
    //}
    //
    //[HttpGet]
    //public async Task<IActionResult> GetAllUsers()
    //{
    //    await Task.CompletedTask;
    //    return Ok(Array.Empty<string>());
    //}
    //
    ////[HttpGet]
    //public async Task<IActionResult> UpdateUser()
    //{
    //    await Task.CompletedTask;
    //    return Ok(Array.Empty<string>());
    //}
    //
    ////[HttpGet]
    //public async Task<IActionResult> DeleteUser()
    //{
    //    await Task.CompletedTask;
    //    return Ok(Array.Empty<string>());
    //}
}