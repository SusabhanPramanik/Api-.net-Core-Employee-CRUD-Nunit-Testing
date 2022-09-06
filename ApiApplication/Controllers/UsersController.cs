using ApiApplication.Constants;
using ApiApplication.Models;
using ApiApplication.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IEmpRepositories _empRepositories;

        public UsersController(IEmpRepositories empRepositories)
        {
            _empRepositories = empRepositories;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public ApiResponse Get()
        {
            var user = _empRepositories.GetUsers();
            if(user != null)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.UsersIdNotFound, user);
            }
            return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.UserIDFound, user);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ApiResponse GetUsersById(int id)
        {
            var response = _empRepositories.GetUsersById(id);
            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.UserIDFound, response.Result);
            }
            return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.UserIDFound, null);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ApiResponse AddUsers([FromBody] Users _user)
        {
            using (var scope = new TransactionScope())
            {
                var response = _empRepositories.AddUsers(_user);
                if (response.StatusCode == (int)HttpStatusCode.OK)
                {
                    scope.Complete();
                    return new ApiResponse(StatusCodes.Status200OK, response.Message, response.Result);
                }

                return new ApiResponse(StatusCodes.Status404NotFound, response.Message, null);
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public ApiResponse UpdateUsers([FromBody] Users _users)
        {
            var response = _empRepositories.UpdateUsers(_users);
            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                return new ApiResponse(StatusCodes.Status200OK, response.Message, response.Result);
            }

            return new ApiResponse(StatusCodes.Status404NotFound, response.Message, null);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ApiResponse DeleteUsers(int id)
        {
            var response = _empRepositories.DeleteUsers(id);
            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                return new ApiResponse(StatusCodes.Status200OK, response.Message, response.Result);
            }

            return new ApiResponse(StatusCodes.Status404NotFound, response.Message, null);
        }
    }
}
