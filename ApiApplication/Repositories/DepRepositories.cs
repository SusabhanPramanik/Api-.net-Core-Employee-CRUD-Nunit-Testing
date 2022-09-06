using ApiApplication.Constants;
using ApiApplication.Context;
using ApiApplication.Models;
using ApiApplication.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Repositories
{
    public class DepRepositories : IDepRepositories
    {
        private readonly ApiDbContext _dbContext;

        public DepRepositories(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //only name validation

        /// <summary>
        /// This code for add a new department into the database
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public ApiResponse AddDepartment(Department department)
        {
            int id = 0;
            var _DepMatch = _dbContext.Departments.Where(x => x.DepartmentaName == department.DepartmentaName).FirstOrDefault();
            if (_DepMatch == null)
            {
                _dbContext.Add(department);

                id = _dbContext.SaveChanges();

                if (id == 1)
                {
                    return  new ApiResponse(StatusCodes.Status200OK, DepConstans.DepCreatedSuccessfully, id);
                }
                else
                {
                    return  new ApiResponse(StatusCodes.Status500InternalServerError, DepConstans.DepCreationFailed,id);
                }
            }
            else
            {
                return  new ApiResponse(StatusCodes.Status409Conflict, DepConstans.DuplicateDepartment, _DepMatch);
            }
        }

       /// <summary>
       /// This code for delete the dpeartment using ID
       /// </summary>
       /// <param name="id"></param>
       /// <param name="department"></param>
       /// <returns></returns>
        public ApiResponse DeleteDepartment(int id)
        {
            int Sap = 0;
            var dep = _dbContext.Departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            if (dep != null)
            {
                var obj = _dbContext.Departments.Remove(dep);
                Sap = _dbContext.SaveChanges();

            }
            if (Sap == 1)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.DepDeleteSuccessfully, Sap);
            }
            return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.DepDeleteFailed, Sap);
        }


        /// <summary>
        /// This code for get the all department details in the list form
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Department> GetDepartments()
        {
            return _dbContext.Departments.ToList();
        }


        /// <summary>
        /// This code for get the department details by using ID("one kind of search operation")
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApiResponse GetDepartmentsById(int id)
        {
           var find = _dbContext.Departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            if (find != null)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.DepIDFound, find);
            }
            return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.DepIDnotFoud, find);
        }

        /// <summary>
        /// This code for update department details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        public ApiResponse UpdateDepartment(Department department)
        {
            _dbContext.Update(department);
            var dep = _dbContext.Departments.SingleOrDefault(f => f.DepartmentId == department.DepartmentId);
            

            if (dep != null)
            {
                var name = _dbContext.Departments.SingleOrDefault(k => k.DepartmentaName == department.DepartmentaName 
                && k.DepartmentId != department.DepartmentId);
                
                if (name == null)
                {
                   //_dbContext.Update(department);
                   int id= _dbContext.SaveChanges();
                    if(id == 1)
                    {
                        return new ApiResponse(StatusCodes.Status200OK, DepConstans.DepUpdateSuccessfully, id);
                    }
                }
                else
                {
                    return new ApiResponse(StatusCodes.Status409Conflict, DepConstans.DepUpdateNameFailed, name);
                }
            }
           return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.DepUpdateFailed, dep);
        }
    }
}




