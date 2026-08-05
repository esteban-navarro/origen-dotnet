using Microsoft.AspNetCore.Mvc;

namespace Origen.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "OK",
            service = "Origen.Api",
            timestamp = DateTime.UtcNow
        });
    }
}