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
    public class UserMapingRepositories : IUserMapingRepositories
    {
        private readonly ApiDbContext _dbContext;

        public UserMapingRepositories(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// This code for add a new UserRoleMapping details into the database
        /// </summary>
        /// <param name="usermapings"></param>
        /// <returns></returns>
        public ApiResponse AddUserRoleMapping(UserRoleMapping usermapings)
        {
            int id = 0;
            var MapMatch = _dbContext.UserRoleMappings.SingleOrDefault(d => d.UserId == usermapings.UserId);
            if(MapMatch == null)
            {
                _dbContext.Add(usermapings);
                id = _dbContext.SaveChanges();
                if (id == 1)
                {
                    return new ApiResponse(StatusCodes.Status200OK, DepConstans.UserMappingCreatedSuccessfully, id);

                }
                else
                {
                    return new ApiResponse(StatusCodes.Status500InternalServerError, DepConstans.UserMappingCreationFailed, id);

                }
            }
            else
            {
                return new ApiResponse(StatusCodes.Status409Conflict, DepConstans.DuplicateUsermapingCreationFailed, MapMatch);
            }
        }
        /// <summary>
        /// This code for delete the UserRoleMapping using ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usermapings"></param>
        /// <returns></returns>
        public ApiResponse DeleteUserRoleMapping(int id)
        {
            int Sap = 0;
            var Emp = _dbContext.UserRoleMappings.Where(m => m.UserRoleMappingId == id).FirstOrDefault();
            if (Emp != null)
            {
                _dbContext.UserRoleMappings.Remove(Emp);
                Sap =_dbContext.SaveChanges();
            }
            if(Sap == 1)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.UserMappingDeleteSuccessfully, Emp);

            }
                return new ApiResponse(StatusCodes.Status500InternalServerError, DepConstans.UserMappingDeleteFailed, Emp);
        }

        /// <summary>
        /// This code for get the all UserRoleMapping details in the list form
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserRoleMapping> GetUserRoleMapping()
        {
            return _dbContext.UserRoleMappings.ToList();
        }

        /// <summary>
        /// This code for get the UserRoleMapping details by using ID("one kind of search operation")
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApiResponse GetUserRoleMappingById(int id)
        {
            var find = _dbContext.UserRoleMappings.Where(m => m.UserRoleMappingId == id).FirstOrDefault();
            if (find != null)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.UsermapIDFound, find);

            }
            return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.UsermapIDNotFound, find);

        }
        /// <summary>
        /// This code for update UserRoleMapping details
        /// </summary>
        /// <param name="usermapings"></param>
        /// <returns></returns>
        public ApiResponse UpdateUserRoleMapping(UserRoleMapping usermapings)
        {
            _dbContext.Update(usermapings);
            var dep = _dbContext.UserRoleMappings.SingleOrDefault(k => k.UserRoleMappingId == usermapings.UserRoleMappingId);
            
            if (dep != null)
            {
                    _dbContext.SaveChanges();
                    return new ApiResponse(StatusCodes.Status200OK, DepConstans.UserMappingUpdateSuccessfully);
            }
            return new ApiResponse(StatusCodes.Status500InternalServerError, DepConstans.UserMappingUpdateFailed);

        }
    }
}
