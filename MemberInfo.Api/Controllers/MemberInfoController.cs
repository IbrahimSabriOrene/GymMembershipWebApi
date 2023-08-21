using Microsoft.AspNetCore.Mvc;

namespace MemberInfo.Api.Controllers;


[Route("api/[controller]")]

public class MemberInfoController : ApiController
{

    [HttpGet]
    public async Task<IActionResult> ListUsers()
    {
        await Task.CompletedTask;
        return Ok(Array.Empty<string>());
    }       
}