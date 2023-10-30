using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers;


[Route("api/[controller]")]

public class CustomerController : ApiController
{

    //ToDo: create members.
    [HttpGet]
    public async Task<IActionResult> CreateUser()
    {
        await Task.CompletedTask;
        return Ok(Array.Empty<string>());
    }


    [HttpGet]
    public async Task<IActionResult> GetUserById()
    {
        await Task.CompletedTask;
        return Ok(Array.Empty<string>());
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        await Task.CompletedTask;
        return Ok(Array.Empty<string>());
    }

    //[HttpGet]
    public async Task<IActionResult> UpdateUser()
    {
        await Task.CompletedTask;
        return Ok(Array.Empty<string>());
    }

    //[HttpGet]
    public async Task<IActionResult> DeleteUser()
    {
        await Task.CompletedTask;
        return Ok(Array.Empty<string>());
    }
}