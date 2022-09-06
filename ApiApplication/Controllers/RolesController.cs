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
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepositories _empRepositories;

        public RolesController(IRoleRepositories empRepositories)
        {
            _empRepositories = empRepositories;
        }
        // GET: api/<EtableController>
        [HttpGet]
        public ApiResponse Get()
        {
            var roles = _empRepositories.GetRoles();
            if(roles != null)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.RoleIDFound, roles);
            }
            return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.RoleIdNotFound, roles);
        }

        // GET api/<EtableController>/5
        [HttpGet("{id}")]
        public ApiResponse GetRolesById(int id)
        {
            var response = _empRepositories.GetRolesById(id);
            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                return new ApiResponse(StatusCodes.Status200OK, response.Message, response.Result);
            }
            else
            {
                return new ApiResponse(StatusCodes.Status404NotFound, response.Message, null);

            }
        }

        // Add new api/<EtableController>
        [HttpPost]
        public ApiResponse AddRoles([FromBody] Roles value)
        {
            using (var scope = new TransactionScope())
            {
                var response = _empRepositories.AddRoles(value);
                if (response.StatusCode == Convert.ToInt32(System.Net.HttpStatusCode.OK))
                {
                    scope.Complete();
                    return new ApiResponse(StatusCodes.Status200OK, response.Message, response.Result);
                }
                return new ApiResponse(StatusCodes.Status409Conflict, response.Message, null);
            }
        }

        // PUT api/<EtableController>/5
        [HttpPut]
        public ApiResponse UpdateRoles([FromBody] Roles value)
        {
            var response = _empRepositories.UpdateRoles(value);
            if (response.StatusCode == Convert.ToInt32(System.Net.HttpStatusCode.OK))
            {
                return new ApiResponse(StatusCodes.Status200OK, response.Message, response.Result);
            }

            return new ApiResponse(StatusCodes.Status409Conflict, response.Message, null);
        }

        // DELETE api/<EtableController>/5
        [HttpDelete("{id}")]
        public ApiResponse DeleteRoles(int id)
        {
            var response = _empRepositories.DeleteRoles(id);
            if (response.StatusCode == Convert.ToInt32(System.Net.HttpStatusCode.OK))
            {
                return new ApiResponse(StatusCodes.Status200OK, response.Message, response.Result);
            }

            return new ApiResponse(StatusCodes.Status409Conflict, response.Message, null);
        }
    }
}
