using ApiApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Repositories.Contracts
{
    public interface IDepRepositories
    {
        IEnumerable<Department> GetDepartments();

        ApiResponse GetDepartmentsById(int id);

        ApiResponse AddDepartment(Department department);
        
        ApiResponse UpdateDepartment(Department department);
        ApiResponse DeleteDepartment(int id);
    }
}
