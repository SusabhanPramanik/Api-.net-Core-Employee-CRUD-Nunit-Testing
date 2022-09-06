using ApiApplication.Constants;
using ApiApplication.Context;
using ApiApplication.Models;
using ApiApplication.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Repositories
{
    public class SalRepositorie : ISalRepositories
    {
        private readonly ApiDbContext _dbContext;

        public SalRepositorie(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// This code for add a new Salary details into the database
        /// </summary>
        /// <param name="salarys"></param>
        /// <returns></returns>
        public ApiResponse AddSalary(Salarys salarys)
        {
            int id = 0;
            var salMatch = _dbContext.Salarys.SingleOrDefault(k => k.UserId == salarys.UserId);
            if(salMatch == null)
            {
                _dbContext.Add(salarys);

                id = _dbContext.SaveChanges();

                if (id == 1)
                {
                    return new ApiResponse(StatusCodes.Status200OK, DepConstans.SalCreatedSuccessfully, id);

                }
            }
            else
            {
                return new ApiResponse(StatusCodes.Status500InternalServerError, DepConstans.SalCreationFailed, id);
            }
            return new ApiResponse(StatusCodes.Status409Conflict, DepConstans.DuplicateSalaryCreationFailed, salMatch);

        }

        /// <summary>
        /// This code for Salary the User using ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="salarys"></param>
        /// <returns></returns>
        public ApiResponse DeleteSalary(int id)
        {
            int Sap = 0;
            var Emp = _dbContext.Salarys.Where(m => m.SalaryId == id).FirstOrDefault();
            if (Emp != null)
            {
                var sal = _dbContext.Salarys.Remove(Emp);
                Sap = _dbContext.SaveChanges();
            }
            if(Sap == 1)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.SalDeleteSuccessfully, Emp);
            }
                return new ApiResponse(StatusCodes.Status500InternalServerError, DepConstans.SalDeleteFailed, Emp);
        }

        /// <summary>
        /// This code for get the all Salary details in the list form
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Salarys> GetSalary()
        {
            return _dbContext.Salarys.ToList();
        }

        /// <summary>
        /// This code for get the Salary details by using ID("one kind of search operation")
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApiResponse GetSalaryById(int id)
        {
            var find = _dbContext.Salarys.Where(m => m.SalaryId == id).FirstOrDefault();
            if(find != null)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.SalIDFound, find);
            }
            return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.SalIdNotFound, find);

        }

        /// <summary>
        /// This code for update Salary details
        /// </summary>
        /// <param name="salarys"></param>
        /// <returns></returns>
        public ApiResponse UpdateSalary(Salarys salarys)
        {
            _dbContext.Update(salarys);
            var dep = _dbContext.Salarys.SingleOrDefault(k => k.SalaryId == salarys.SalaryId);

            if (dep != null)
            {
                var userid = _dbContext.Salarys.SingleOrDefault(k => k.UserId == salarys.UserId
                && k.SalaryId != salarys.SalaryId);

                if (userid != null)
                {

                   int id = _dbContext.SaveChanges();
                    if(id == 1)
                    {
                        return new ApiResponse(StatusCodes.Status200OK, DepConstans.SalUpdateSuccessfully,id);
                    }
                }
                else
                {
                    return new ApiResponse(StatusCodes.Status500InternalServerError, DepConstans.SalUpdateDuplicateFailed, userid);
                }
            }
            return new ApiResponse(StatusCodes.Status500InternalServerError, DepConstans.SalUpdateFailed,dep);

        }
    }
}
