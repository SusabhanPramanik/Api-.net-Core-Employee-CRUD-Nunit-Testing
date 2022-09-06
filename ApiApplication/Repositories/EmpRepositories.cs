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
    public class EmpRepositories : IEmpRepositories
    {
        private readonly ApiDbContext _dbContext;

        public EmpRepositories(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// This code for add a new User details into the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ApiResponse AddUsers(Users user)
        {
            int id = 0;
            var cheak1 = _dbContext.Users.SingleOrDefault(y => y.Username == user.Username || y.employeeCode == user.employeeCode);
            if (cheak1 == null)
            {
                _dbContext.Add(user);
                id = _dbContext.SaveChanges();
                if (id == 1)
                {
                    return new ApiResponse(StatusCodes.Status200OK, DepConstans.UserCreatedSuccessfully, id);
                }
            }
            else
            {
                return new ApiResponse(StatusCodes.Status500InternalServerError, DepConstans.DuplicateUserCreationFailed, cheak1);

            }
            return new ApiResponse(StatusCodes.Status409Conflict, DepConstans.UserCreationFailed, cheak1);

        }

        /// <summary>
        /// This code for delete the User using ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public ApiResponse DeleteUsers(int id)
        {
            int delete = 0;
            var Emp = _dbContext.Users.Where(m => m.UserId == id).FirstOrDefault();
            if (Emp != null)
            {
               var obj = _dbContext.Users.Remove(Emp);
                delete = _dbContext.SaveChanges();
            }
            if(delete == 1) 
            { 
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.UserDeleteSuccessfully, delete);
            }
                return new ApiResponse(StatusCodes.Status500InternalServerError, DepConstans.UserDeleteFailed, delete);
        }

        /// <summary>
        /// /// <summary>
        /// This code for get the all Users details in the list form
        /// </summary>
        /// <returns></returns>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Users> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        /// <summary>
        /// This code for get the Users details by using ID("one kind of search operation")
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApiResponse GetUsersById(int id)
        {
            var find = _dbContext.Users.Where(m => m.UserId == id).FirstOrDefault();
            if(find != null)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.UserIDFound, find);

            }
            return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.UsersIdNotFound, find);

        }

        /// <summary>
        /// This code for update Users details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        public ApiResponse UpdateUsers(Users user)
        {
            _dbContext.Update(user);
            var userid = _dbContext.Users.SingleOrDefault(f => f.UserId == user.UserId);
            if (userid != null)
            {
                var userCode = _dbContext.Users.SingleOrDefault(y => (y.Username == user.Username
                || y.employeeCode == user.employeeCode) && y.UserId != user.UserId);

                if (userCode == null)
                {
                  //_dbContext.Update(user);
                  int id = _dbContext.SaveChanges();
                    if(id==1)
                    {
                        return new ApiResponse(StatusCodes.Status200OK, DepConstans.UserUpdateSuccessfully);
                    }
                }
                else
                {
                    return new ApiResponse(StatusCodes.Status409Conflict, DepConstans.UserUpdateDuplicateFailed, userCode);
                }
            }
            return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.UserUpdateFailed,userid);
        }
    }
}
