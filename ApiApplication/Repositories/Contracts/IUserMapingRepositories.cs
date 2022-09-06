using ApiApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Repositories.Contracts
{
    public interface IUserMapingRepositories
    {
        IEnumerable<UserRoleMapping> GetUserRoleMapping();
        ApiResponse GetUserRoleMappingById(int id);
        ApiResponse AddUserRoleMapping(UserRoleMapping usermapings);
        ApiResponse UpdateUserRoleMapping(UserRoleMapping usermapings);
        ApiResponse DeleteUserRoleMapping(int id);
    }
}
