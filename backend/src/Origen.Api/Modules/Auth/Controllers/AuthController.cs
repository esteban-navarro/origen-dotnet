using Microsoft.AspNetCore.Mvc;
using Origen.Api.Modules.Auth.DTOs;
using Origen.Api.Modules.Auth.Services;

namespace Origen.Api.Modules.Auth.Controllers;

[ApiController]
[Route("/api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(
        LoginRequest request)
    {
        LoginResponse response =
            await _authService.LoginAsync(request);

        return Ok(response);
    }
}