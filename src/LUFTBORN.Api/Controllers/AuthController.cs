using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LUFTBORN.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
 
    [HttpGet("ping")]
    public IActionResult AnonymousPing() => Ok("public, no auth needed");

    [Authorize]
    [HttpGet("whoami")]
    public IActionResult Protected()
    {
        var claims = User.Claims.Select(c => new { c.Type, c.Value });
        return Ok(new { message = "you're authenticated", claims });
    }
}