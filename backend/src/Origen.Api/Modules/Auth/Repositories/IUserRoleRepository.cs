using Origen.Api.Modules.Auth.Entities;

namespace Origen.Api.Modules.Auth.Repositories;

public interface IUserRoleRepository
{
    Task AddAsync(UserRole userRole);
}