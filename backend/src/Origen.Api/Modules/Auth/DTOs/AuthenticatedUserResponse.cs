namespace Origen.Api.Modules.Auth.DTOs
{
    public sealed class AuthenticatedUserResponse
    {
        public Guid Id { get; init; }

        public string Username { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;

        public string FirstName { get; init; } = string.Empty;

        public string LastName { get; init; } = string.Empty;

        public IEnumerable<string> Roles { get; init; } = [];

        public IEnumerable<string> Permissions { get; init; } = [];
    }
}
