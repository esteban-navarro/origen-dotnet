using Origen.Api.Modules.Auth.Entities;

namespace Origen.Api.Modules.Auth.Repositories;

public interface IUserRepository
{
    Task<User?> FindByUsernameAsync(string username);

    Task<User?> FindByEmailAsync(string email);

    Task<bool> ExistsByUsernameAsync(string username);

    Task<bool> ExistsByEmailAsync(string email);

    Task AddAsync(User user);
}