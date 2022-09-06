using ApiApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Repositories.Contracts
{
    public interface ISalRepositories
    {
        IEnumerable<Salarys> GetSalary();
        ApiResponse GetSalaryById(int id);
        ApiResponse AddSalary(Salarys salarys);
        ApiResponse UpdateSalary(Salarys salarys);
        ApiResponse DeleteSalary(int id);
    }
}
