using Microsoft.AspNetCore.Mvc;

namespace Origen.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
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