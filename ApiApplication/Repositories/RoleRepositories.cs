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
    public class RoleRepositories : IRoleRepositories
    {
        private readonly ApiDbContext _dbContext;

        public RoleRepositories(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// This code for add a new Roles details into the database
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public ApiResponse AddRoles(Roles roles)
        {
            int id = 0;
            var name = _dbContext.Roles.SingleOrDefault(f => f.RoleName == roles.RoleName);
            if(name == null)
            {
                _dbContext.Add(roles);

                id = _dbContext.SaveChanges();

                if(id == 1)
                {
                    return new ApiResponse(StatusCodes.Status200OK, DepConstans.RoleCreatedSuccessfully, id);

                }
                else
                {
                    return new ApiResponse(StatusCodes.Status500InternalServerError, DepConstans.RoleCreationFailed, id);

                }
            }
            else
            {
                return new ApiResponse(StatusCodes.Status409Conflict, DepConstans.DuplicateRoleCreationFailed, name);

            }

        }
        /// <summary>
        /// This code for delete the Roles using ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public ApiResponse DeleteRoles(int id)
        {
            int Sap = 0;
            var Emp = _dbContext.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (Emp != null)
            {
                _dbContext.Roles.Remove(Emp);
                Sap = _dbContext.SaveChanges();
            }
            if(Sap == 1)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.RoleDeleteSuccessfully, Sap);

            }
                return new ApiResponse(StatusCodes.Status500InternalServerError, DepConstans.RoleDeleteFailed, Sap);
        }

        /// <summary>
        /// This code for get the all Roles details in the list form
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Roles> GetRoles()
        {
            return _dbContext.Roles.ToList();
        }

        /// <summary>
        /// This code for get the Roles details by using ID("one kind of search operation")
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApiResponse GetRolesById(int id)
        {
            var find = _dbContext.Roles.Where(k => k.RoleId == id).FirstOrDefault();
            if (find != null)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.RoleIDFound, find);
            }
                return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.RoleIdNotFound, find);
        }

        /// <summary>
        /// This code for update Roles details
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public ApiResponse UpdateRoles(Roles roles)
        {
            _dbContext.Update(roles);
            var dep = _dbContext.Roles.SingleOrDefault(x => x.RoleId == roles.RoleId);
            if (dep != null)
            {
                var name = _dbContext.Roles.SingleOrDefault(k => k.RoleName == roles.RoleName
                && k.RoleId != roles.RoleId);

                if (name == null)
                {
                    int id = _dbContext.SaveChanges();
                    if(id == 1)
                    {
                        return new ApiResponse(StatusCodes.Status200OK, DepConstans.RoleUpdateSuccessfully);
                    }
                }
                else
                {
                    return new ApiResponse(StatusCodes.Status409Conflict, DepConstans.UpdateRoleCreationFailed);

                }
            }
            return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.RoleUpdateFailed);

        }
    }
}
