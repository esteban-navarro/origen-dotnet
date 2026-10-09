using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Origen.Api.Modules.Users.DTO.Requests;
using Origen.Api.Modules.Users.DTO.Responses;
using Origen.Api.Modules.Users.Services;

namespace Origen.Api.Modules.Users.Controllers;

[ApiController]
[Route("/api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize(Roles = "ADMIN")]
    public async Task<ActionResult<List<UserResponse>>> GetAll()
    {
        List<UserResponse> response =
            await _userService.GetAllAsync();

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<UserResponse>> GetById(Guid id)
    {
        UserResponse? response =
            await _userService.GetByIdAsync(id);

        if (response is null)
        {
            return NotFound(new
            {
                message = "User not found."
            });
        }

        return Ok(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<UserResponse>> Create(
        CreateUserRequest request)
    {
        try
        {
            UserResponse response =
                await _userService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = response.Id },
                response);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new
            {
                message = ex.Message
            });
        }
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<UserResponse>> Update(
        Guid id,
        UpdateUserRequest request)
    {
        try
        {
            UserResponse? response =
                await _userService.UpdateAsync(id, request);

            if (response is null)
            {
                return NotFound(new
                {
                    message = "User not found."
                });
            }

            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new
            {
                message = ex.Message
            });
        }
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        bool deleted =
            await _userService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "User not found."
            });
        }

        return NoContent();
    }
}