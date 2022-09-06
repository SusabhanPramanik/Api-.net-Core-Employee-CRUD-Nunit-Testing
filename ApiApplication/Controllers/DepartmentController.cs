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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepRepositories _empRepositories;

        public DepartmentController(IDepRepositories empRepositories)
        {
            _empRepositories = empRepositories;
        }
        
        // GET: api/<EtableController>
        [HttpGet]
        public ApiResponse  Get()
        {
            var dep = _empRepositories.GetDepartments();
            if(dep != null)
            {
                return new ApiResponse(StatusCodes.Status200OK, DepConstans.DepIDFound, dep);
            }
            return new ApiResponse(StatusCodes.Status404NotFound, DepConstans.DepIDnotFoud, dep);
        }

        // GET api/<EtableController>/5
        [HttpGet("{id}")]
        public ApiResponse GetDepartmentsById(int id)
        {
            var response = _empRepositories.GetDepartmentsById(id);
            if(response.StatusCode == (int)HttpStatusCode.OK)
            {
                return new ApiResponse(StatusCodes.Status200OK, response.Message, response.Result);
            }
            else
            {
                return new ApiResponse(StatusCodes.Status404NotFound, response.Message, null);

            }
        }

        // POST api/<EtableController>
        [HttpPost]
        public ApiResponse AddDepartment([FromBody] Department department)
        {

            // return  Ok(_empRepositories.AddDepartment(department));

            var responce = _empRepositories.AddDepartment(department);
            if (responce.StatusCode == (int)HttpStatusCode.OK)
            {
              //  return Ok(responce.Message);
                return new ApiResponse(StatusCodes.Status200OK, responce.Message, responce.Result);
            }
            return new ApiResponse(StatusCodes.Status409Conflict, responce.Message, null);

        }

        // PUT api/<EtableController>/5
        [HttpPut]
        public ApiResponse UpdateDepartment([FromBody] Department department)
        {


            //return Ok(_empRepositories.UpdateDepartment(value));

            var response = _empRepositories.UpdateDepartment(department);
            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                return new ApiResponse(StatusCodes.Status200OK, response.Message, response.Result);
            }

            return new ApiResponse(StatusCodes.Status409Conflict, response.Message, null);

        }

        // DELETE api/<EtableController>/5
        [HttpDelete("{id}")]
        public ApiResponse DeleteDepartment(int id)
        {
           var response =  _empRepositories.DeleteDepartment(id);
            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                return new ApiResponse(StatusCodes.Status200OK, response.Message, response.Result);
            }

            return new ApiResponse(StatusCodes.Status409Conflict, response.Message, null);

        }
    }
}
