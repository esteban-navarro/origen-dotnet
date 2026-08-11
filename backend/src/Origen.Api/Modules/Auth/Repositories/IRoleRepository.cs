using Origen.Api.Modules.Auth.Entities;

namespace Origen.Api.Modules.Auth.Repositories;

public interface IRoleRepository
{
    Task<Role?> FindByNameAsync(string name);

    Task<bool> ExistsByNameAsync(string name);
}
