using ApiApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Repositories.Contracts
{
    public interface IRoleRepositories
    {
        IEnumerable<Roles> GetRoles();
        ApiResponse GetRolesById(int id);
        ApiResponse AddRoles(Roles roles);
        ApiResponse UpdateRoles(Roles roles);
        ApiResponse DeleteRoles(int id);
    }
}
