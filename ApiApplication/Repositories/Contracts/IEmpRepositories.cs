using ApiApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Repositories.Contracts
{
    public interface IEmpRepositories
    {
        IEnumerable<Users> GetUsers();
        ApiResponse GetUsersById(int id);
        ApiResponse AddUsers(Users user);
        ApiResponse UpdateUsers(Users user);
        ApiResponse DeleteUsers(int id);
    }
}
