namespace Origen.Api.Modules.Users.DTO.Responses;

public class UserResponse
{
    public Guid Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public bool Enabled { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}